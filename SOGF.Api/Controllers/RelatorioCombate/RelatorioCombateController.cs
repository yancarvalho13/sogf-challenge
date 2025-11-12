using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Contracts.Service;

namespace Solution.Api.Controllers.RelatorioCombate;

[ApiController]
[Route("api/v1")]
[Authorize]
public class RelatorioCombateController : BaseController
{

    private readonly IRelatorioCombateService _service;

    public RelatorioCombateController(IRelatorioCombateService service)
    {
        _service = service;
    }

    [HttpPost("iniciar-combate")]
    public async Task<IActionResult> IniciarCombate()
    {
        var response = await _service.IniciarCombate();
        return HandleResponse(response);
    }

    [HttpGet("relatorio-combate")]
    public async Task<IActionResult> BuscarRelatorios()
    {
        var response = await _service.GetAllAsync();
        return HandleResponse(response);
    }

    [HttpGet("relatorio-piloto/{id}")]
    public async Task<IActionResult> BuscarRelatorioPiloto(long id)
    {
        var response = await _service.BuscarRelatorioPiloto(id);
        return HandleResponse(response);
    }

    [HttpGet("relatorio-faccao/{id}")]
    public async Task<IActionResult> BuscarRelatorioFaccao(long id)
    {
        var response = await _service.BuscarRelatorioFaccao(id);
        return HandleResponse(response);
    }

}