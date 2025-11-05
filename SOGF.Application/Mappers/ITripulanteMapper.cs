using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public interface ITripulanteMapper : IMapper<Tripulante, TripulanteRequest, TripulanteResponse>
{
    public PilotarNaveResponse ToPilotarNaveDto(Tripulante tripulanteEntity, Nave naveEntity);
}