using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto.Missao;

namespace Solution.Application.Mappers;

public class MissaoMapper : IMapper<Missao, MissaoRequest, MissaoResponse>, IMissaoMapper
{
    public Missao ToEntity(MissaoRequest request) =>
        new Missao(request.objetivoMissao,
            request.setorGalatico,
            request.naveId,
            request.pilotoId,
            request.tripulantesId.Select(t => new MissaoTripulantes(t)).ToList());
    

    public MissaoResponse ToDto(Missao entity) =>
        new MissaoResponse(entity.Id,
            entity.ObjetivoMissao,
            entity.SetorGalatico,
            entity.StatusMissao,
            entity.NaveId,
            entity.PilotoId,
            entity.Tripulantes.Select(t => new MissaoTripulanteResponse(t.TripulanteId)).ToList());
    
}