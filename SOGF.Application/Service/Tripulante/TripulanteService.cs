using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;
using Solution.Application.Validations;

namespace Solution.Application.Service.Tripulante;

public class TripulanteService(
    ITripulanteRepository tripulanteRepository,
    ITripulanteMapper tripulanteMapper,
    INaveRepository naveRepository,
    TripulanteValidator validator)
    : GenericService<SOGF.Domain.Model.Tripulante, TripulanteRequest, TripulanteResponse>(tripulanteRepository,
        tripulanteMapper, validator), ITripulanteService
{

    private readonly ITripulanteRepository _tripulanteRepository = tripulanteRepository;
    private readonly ITripulanteMapper _tripulanteMapper = tripulanteMapper;
    private readonly INaveRepository _naveRepository = naveRepository;
}