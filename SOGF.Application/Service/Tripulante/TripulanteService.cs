using Solution.Application.Contracts.Persistence;
using Solution.Application.Dto;
using Solution.Application.Mappers;

namespace Solution.Application.Service.Tripulante;

public class TripulanteService : GenericService<SOGF.Domain.Model.Tripulante, TripulanteRequest, TripulanteResponse>, ITripulanteService
{

    private readonly ITripulanteRepository _tripulanteRepository;
    private readonly ITripulanteMapper _tripulanteMapper;

    public TripulanteService(ITripulanteRepository tripulanteRepository, ITripulanteMapper tripulanteMapper) 
        : base(tripulanteRepository, tripulanteMapper)
    {
        _tripulanteRepository = tripulanteRepository;
        _tripulanteMapper = tripulanteMapper;
    }
  
}