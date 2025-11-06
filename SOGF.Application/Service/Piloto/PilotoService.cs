using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Piloto;

namespace Solution.Application.Service.Piloto;

public class PilotoService(IPilotoRepository repository,
    IPilotoMapper mapper)
: GenericService<SOGF.Domain.Model.Piloto, PilotoRequest, PilotoResponse>(repository, mapper),
    IPilotoService
{
    
}