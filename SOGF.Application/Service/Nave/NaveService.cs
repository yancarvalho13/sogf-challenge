using SOGF.Shared.Result;
using Solution.Application.Contracts.Adapters;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Validations;

namespace Solution.Application.Service.Nave;

public class NaveService(
    INaveRepository naveRepository,
    ITripulanteRepository tripulanteRepository,
    INaveMapper naveMapper,
    NaveRequestValidator validator,
    IRelatorioCombateRepository relatorioCombateRepository,
    ILlMAdapter llMAdapter,
    IFaccaoRepository faccaoRepository)
    : GenericService<SOGF.Domain.Model.Nave, NaveRequest, NaveResponse>(naveRepository, naveMapper, validator),
        INaveService
{
    private readonly INaveRepository _naveRepository = naveRepository;
    private readonly ITripulanteRepository _tripulanteRepository = tripulanteRepository;
    private readonly INaveMapper _naveMapper = naveMapper;
    public async Task<Result<string>> ResumoNave(long id)
    {var relatorios = await relatorioCombateRepository.GetAllAsync();

        var resumo = relatorios
            .Where(r => r.NavesEngajadas.Any(n => n.NaveId == id))
            .ToList();

        var nave = await _naveRepository.GetByIdAsync(id);

        var baseText = string.Join("\n- ", resumo
            .Where(r => !string.IsNullOrWhiteSpace(r.DescricaoTatica))
            .Select(r => r.DescricaoTatica!.Trim()));

        var faccao = await faccaoRepository.GetByIdAsync(nave.FaccaoId);
        var faccaoNome = faccao.Nome;

        var prompt = string.IsNullOrWhiteSpace(baseText)
            ? @$"Em até 400 caracteres, conte uma breve história de origem da nave {nave.Nome} ({faccaoNome}) no universo Star Wars. 
            Use terceira pessoa, tom épico, frases curtas, coesas, sem títulos e sem emojis. 
            Deixe claro que ela ainda não tem experiência em combate."
            : @$"Em até 400 caracteres, resuma a história da nave {nave.Nome} ({faccaoNome}) com base nos combates abaixo, destacando marcos, vitórias/derrotas e evolução. 
            Use terceira pessoa, tom épico de Star Wars, frases curtas, coesas, sem títulos e sem emojis. 
            Não invente nada além do texto-base.
            TEXTO-BASE:
            {baseText}";
        
        var response = await llMAdapter.Consult(prompt);

        return response;
    }
    
}