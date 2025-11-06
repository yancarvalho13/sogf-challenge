using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Application.Contracts.Mapping;

public interface ITripulanteMapper : IMapper<Tripulante, TripulanteRequest, TripulanteResponse>
{
    public PilotarNaveResponse ToPilotarNaveDto(Tripulante tripulanteEntity, Nave naveEntity);
}