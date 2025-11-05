using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;

namespace Solution.Application.Service.Tripulante;

public class TripulanteService : GenericService<SOGF.Domain.Model.Tripulante, TripulanteRequest, TripulanteResponse>, ITripulanteService
{

    private readonly ITripulanteRepository _tripulanteRepository;
    private readonly ITripulanteMapper _tripulanteMapper;
    private readonly INaveRepository _naveRepository;

    public TripulanteService(ITripulanteRepository tripulanteRepository, ITripulanteMapper tripulanteMapper, INaveRepository naveRepository) 
        : base(tripulanteRepository, tripulanteMapper)
    {
        _tripulanteRepository = tripulanteRepository;
        _tripulanteMapper = tripulanteMapper;
        _naveRepository = naveRepository;
    }
    
}