using Solution.Application.Contracts.Service;
using Solution.Application.Dto;

namespace Solution.Application.Service.Tripulante;

public interface ITripulanteService : IGenericService<SOGF.Domain.Model.Tripulante, TripulanteRequest, TripulanteResponse>
{
    
}