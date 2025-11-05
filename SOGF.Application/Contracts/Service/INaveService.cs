using Solution.Application.Dto;

namespace Solution.Application.Contracts.Service;

public interface INaveService : IGenericService<SOGF.Domain.Model.Nave,CreateNaveRequest,NaveResponse>
{
    
    
    Task<EnlistTripulanteResponse> EnlistTripulante(long tripulanteId, long naveId);

}