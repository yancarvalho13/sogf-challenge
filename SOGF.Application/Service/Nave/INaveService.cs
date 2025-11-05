using Solution.Application.Contracts.Service;
using Solution.Application.Dto;

namespace Solution.Application.Service.Nave;

public interface INaveService : IGenericService<SOGF.Domain.Model.Nave,CreateNaveRequest,NaveResponse>
{
    
    Task<EnlistPilotResponse> EnlistPilot(long pilotId, long naveId);
    
    Task<EnlistTripulanteResponse> EnlistTripulante(long tripulanteId, long naveId);

}