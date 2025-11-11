using SOGF.Domain.Entity.Result;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Piloto;
using Solution.Application.Validations;

namespace Solution.Application.Service.Piloto;

public class PilotoService(IPilotoRepository repository,
    IPilotoMapper mapper,
    PilotoRequestValidator validator,
    IRelatorioCombateRepository relatorioCombateRepository,
    ILlMAdapter adapter)   
: GenericService<SOGF.Domain.Model.Piloto, PilotoRequest, PilotoResponse>(repository, mapper, validator),
    IPilotoService
{
    public async Task<Result<string>> ResumoPiloto(long id)
    {
        var relatorios = await relatorioCombateRepository.GetAllAsync();
        var resumo = relatorios.Where(r
            => r.NavesEngajadas.Any(n => n.PilotoId == id)).ToList();
        
        var baseText = string.Join("\n- ", resumo
            .Where(r => !string.IsNullOrWhiteSpace(r.DescricaoTatica))
            .Select(r => r.DescricaoTatica!.Trim()));


        var prompt = @$"Resuma em até 400 caracteres a história do piloto com base nos combates abaixo, destacando marcos, vitórias/derrotas e evolução. 
        Use terceira pessoa, frases curtas, coesas, sem títulos, sem emojis. Não invente dados além do texto-base e utilize a tematica de star wars.
        se o texto base estiver vazio, invente uma historia de origem e diga que ele ainda nao tem experiencia.  
        TEXT0-BASE:
        {baseText}";

        var response = await adapter.Consult(prompt);

        return response;
    }
}