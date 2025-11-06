using SOGF.Domain.Model;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Piloto;

namespace Solution.Api.Controllers.PilotoController;

public class PilotoController(IPilotoService service)
: GenericController<Piloto, PilotoRequest, PilotoResponse>(service),
    IPilotoController
{
    
}