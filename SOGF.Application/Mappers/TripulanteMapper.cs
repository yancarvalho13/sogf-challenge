using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public class TripulanteMapper : IMapper<Tripulante, TripulanteRequest, TripulanteResponse>, ITripulanteMapper
{
    public Tripulante ToEntity(TripulanteRequest request) => 
        new Tripulante(request.nome, request.patente, request.especialidade); 

    public TripulanteResponse ToDto(Tripulante entity) => 
        new TripulanteResponse(entity.Id, entity.Nome, entity.Patente, entity.Especialidade);

    public PilotarNaveResponse ToPilotarNaveDto(Tripulante tripulanteEntity, Nave naveEntity) =>
        new PilotarNaveResponse(naveEntity.Id, tripulanteEntity.Id, naveEntity.Nome, tripulanteEntity.Nome);
}