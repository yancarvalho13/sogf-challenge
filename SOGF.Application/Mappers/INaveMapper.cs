using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public interface INaveMapper : IMapper<Nave, CreateNaveRequest, NaveResponse>
{
    EnlistPilotResponse ToEnlistPilotDto(Nave entity, Tripulante tripulanteEntity);
    EnlistTripulanteResponse ToEnlistTripulantDto(Nave entity);

}