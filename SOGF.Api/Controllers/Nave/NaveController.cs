using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Api.Controllers.Common;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Service.Nave;

namespace Solution.Api.Controllers.Nave;

[ApiController]
[Route("api/v1/")]
[Authorize]
public class NaveController(INaveService naveService)
    : GenericController<SOGF.Domain.Model.Nave, NaveRequest, NaveResponse>(naveService), INaveController
{
    [HttpGet("resumo-da-nave/{id}")]
    public async Task<IActionResult> ResumoNave(long id)
    {
        var response = await naveService.ResumoNave(id);
        return HandleResponse(response);
    }
    
    
}