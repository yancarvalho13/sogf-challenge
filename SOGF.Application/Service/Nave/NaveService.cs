using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;

namespace Solution.Application.Service.Nave;

public class NaveService(
    INaveRepository naveRepository,
    ITripulanteRepository tripulanteRepository,
    INaveMapper naveMapper)
    : GenericService<SOGF.Domain.Model.Nave, CreateNaveRequest, NaveResponse>(naveRepository, naveMapper), INaveService
{
    private readonly INaveRepository _naveRepository = naveRepository;
    private readonly ITripulanteRepository _tripulanteRepository = tripulanteRepository;
    private readonly INaveMapper _naveMapper = naveMapper;
}