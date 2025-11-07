using FluentValidation;
using SOGF.Domain;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
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

    public MissaoService(IMissaoRepository missaoRepository, IMissaoMapper missaoMapper, IValidator<MissaoRequest> validator, ITripulanteRepository tripulanteRepository, IPilotoRepository pilotoRepository, INaveRepository naveRepository, MissaoRequestValidator validator1)
    {
        _missaoRepository = missaoRepository;
        _missaoMapper = missaoMapper;
        _tripulanteRepository = tripulanteRepository;
        _pilotoRepository = pilotoRepository;
        _naveRepository = naveRepository;
        _validator = validator1;
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
        
        
        if (naveInMissao != null) return Errors.NaveInMission;

        
        if (pilotoInMissao != null) return Errors.PilotoInMission;


        if (IsTripulantesInMission(missoesDb,request.tripulantesId).Result) return Errors.TripulanteInMission;

        
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
        if (missaoDb is null) return Errors.MissaoNotFound;
        return _missaoMapper.ToDto(missaoDb);
    }


    public async Task<Result<MissaoResponse>> FinalizaMissao(long id)
    {
        var missaoDb = await _missaoRepository.GetByIdAsync(id);
        if (missaoDb is null ) return Errors.MissaoNotFound;
        if (missaoDb.StatusMissao == StatusMissao.Completada) return Errors.MissaoCompletada;
        missaoDb.FinalizarMissao();
        await _missaoRepository.UpdateAsync(missaoDb);
        return _missaoMapper.ToDto(missaoDb);
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