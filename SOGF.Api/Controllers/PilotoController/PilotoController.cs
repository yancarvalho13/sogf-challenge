using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Api.Contracts;
using Solution.Api.Controllers.Common;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Piloto;

namespace Solution.Api.Controllers.PilotoController;

[ApiController]
[Route("api/v1/")]
[Authorize]
public class PilotoController(IPilotoService service)
: GenericController<Piloto, PilotoRequest, PilotoResponse>(service),
    IPilotoController
{
    [HttpGet("resumo-do-piloto/{id}")]
    public async Task<IActionResult> ResumoPiloto(long id)
    {
        var response = await service.ResumoPiloto(id);
        return HandleResponse(response);
    }
}