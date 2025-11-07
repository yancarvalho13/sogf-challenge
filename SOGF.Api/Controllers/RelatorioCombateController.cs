using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;

namespace Solution.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class RelatorioCombateController : BaseController
{

    private readonly IRelatorioCombateService _service;

    public RelatorioCombateController(IRelatorioCombateService service)
    {
        _service = service;
    }

    [HttpPost("/iniciar-combate")]
    public async Task<IActionResult> IniciarCombate()
    {
        var response = await _service.IniciarCombate();
        return Ok(response);
    }
    
}