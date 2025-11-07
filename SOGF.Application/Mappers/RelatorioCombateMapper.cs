using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Mappers;

public class RelatorioCombateMapper : IRelatorioCombateMapper
{
    public RelatorioCombateResponse ToDto(RelatorioCombate entity)
    {
        return new RelatorioCombateResponse(entity.Id,
            entity.Data,
            entity.Resultado,
            entity.DescricaoTatica,
            entity.FaccaoVencedoraId,
            entity.NavesEngajadas
                .Select(ne
                    => new EngajamentoCombateResponse(ne.NaveId,
                        ne.PilotoId,
                        ne.RelatorioCombateId,
                        ne.Resultado)).ToList());
    }
}