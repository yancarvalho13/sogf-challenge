using FluentValidation;
using SOGF.Domain;
using SOGF.Domain.Model;
using SOGF.Shared.Result;
using Solution.Application.Contracts.Adapters;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Dto.LlmAdapter;
using Solution.Application.Dto.Missao;
using Solution.Application.Validations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Solution.Application.Service.Missao;

public class MissaoService : IMissaoService
{
    private readonly IMissaoRepository _missaoRepository;
    private readonly INaveRepository _naveRepository;
    private readonly IPilotoRepository _pilotoRepository;
    private readonly ITripulanteRepository _tripulanteRepository;
    private readonly IMissaoMapper _missaoMapper;
    private readonly MissaoRequestValidator _validator;
    private readonly IRelatorioCombateRepository _relatorioCombateRepository;
    private readonly ILlMAdapter _llMAdapter;

    public MissaoService(IMissaoRepository missaoRepository, IMissaoMapper missaoMapper, IValidator<MissaoRequest> validator, ITripulanteRepository tripulanteRepository, IPilotoRepository pilotoRepository, INaveRepository naveRepository, MissaoRequestValidator validator1, IRelatorioCombateRepository relatorioCombateRepository, ILlMAdapter llMAdapter)
    {
        _missaoRepository = missaoRepository;
        _missaoMapper = missaoMapper;
        _tripulanteRepository = tripulanteRepository;
        _pilotoRepository = pilotoRepository;
        _naveRepository = naveRepository;
        _validator = validator1;
        _relatorioCombateRepository = relatorioCombateRepository;
        _llMAdapter = llMAdapter;
    }

    public async Task<Result<MissaoResponse>> IniciarMissao(MissaoRequest request)
    {
        var isValid = await _validator.ValidateAsync(request);
        var validationErrors =  ValidateRequest(isValid);
        if (validationErrors.Count != 0) return validationErrors;

        var missoesDb = await _missaoRepository.GetMissoesEmAndamento();
        
        var pilotoInMissao = missoesDb.FirstOrDefault(m
            => m.PilotoId == request.pilotoId);
        
        var naveInMissao = missoesDb.FirstOrDefault(m
            => m.NaveId == request.naveId);
        
        
        if (naveInMissao != null) return DomainErrors.NaveInMission;

        
        if (pilotoInMissao != null) return DomainErrors.PilotoInMission;


        if (IsTripulantesInMission(missoesDb,request.tripulantesId).Result) return DomainErrors.TripulanteInMission;

        
        var entity = _missaoMapper.ToEntity(request);

        entity.IniciarMissao();
        
        await _missaoRepository.CreateAsync(entity);

        Console.WriteLine(entity.StatusMissao);
        
        return _missaoMapper.ToDto(entity);

    }

    public async Task<Result<List<MissaoResponse>>> BuscarMissoes()
    {
        var missaoDb = await _missaoRepository.GetAllAsync();
        var response = missaoDb.Select(m => _missaoMapper.ToDto(m)).ToList();
        return response;
    }

    public async Task<Result<MissaoResponse>> BuscarMissao(long id)
    {
        var missaoDb = await _missaoRepository.GetByIdAsync(id);
        if (missaoDb is null) return DomainErrors.MissaoNotFound;
        return _missaoMapper.ToDto(missaoDb);
    }


    public async Task<Result<MissaoResponse>> FinalizaMissao(long id)
    {
        var missaoDb = await _missaoRepository.GetByIdAsync(id);
        if (missaoDb is null ) return DomainErrors.MissaoNotFound;
        if (missaoDb.StatusMissao == StatusMissao.Completada) return DomainErrors.MissaoCompletada;
        missaoDb.FinalizarMissao();
        await _missaoRepository.UpdateAsync(missaoDb);
        return _missaoMapper.ToDto(missaoDb);
    }

    public async Task<Result<string>> RelatorioInterGalactico()
    {
        var missoes = await _missaoRepository.GetMissoesEmAndamento();
        var relatorios = await _relatorioCombateRepository.GetAllAsync();

        var prompt = "Baseado no relatorio de missoes, faça um resumo dos acontecimentos" +
                     "integalacticos do universo de star wars com ate 600 caracteres, resumos:" +
                     $"{String.Join(", ", relatorios.Select(r => r.DescricaoTatica))}";

        var response = _llMAdapter.Consult(prompt);

        return response.Result;

    }

    private List<ValidationFailureResponse> ValidateRequest(ValidationResult validationResult)
    {

        return validationResult.IsValid
            ? new List<ValidationFailureResponse>()
            : validationResult.Errors.Select(e =>
                new ValidationFailureResponse(e.PropertyName, e.ErrorMessage, e.AttemptedValue.ToString())).ToList();

    }
    private async Task<bool> IsTripulantesInMission(List<SOGF.Domain.Model.Missao> missoes,List<long> tripulantesRequest)
    {
        var tripulantesEncontrados =
            tripulantesRequest.Where(id => missoes.Any(m => m.GetTripulantesId().Contains(id))).ToList();
        return tripulantesEncontrados.Count > 0;

    }
}