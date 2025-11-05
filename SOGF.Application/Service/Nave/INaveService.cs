using Solution.Application.Dto;

namespace Solution.Application.Service.Nave;

public interface INaveService
{
    Task<NaveResponse> GetByIdAsync(long id);
    Task<NaveResponse> CreateAsync(CreateNaveRequest request);

    Task<GetAllNavesResponse> GetAllAsync();

    Task<Boolean> DeleteByIdAsync(long id);

    Task<EnlistPilotResponse> EnlistPilot(long pilotId, long naveId);
    
    Task<EnlistTripulanteResponse> EnlistTripulante(long tripulanteId, long naveId);

}