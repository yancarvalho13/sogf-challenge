using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Missao;

namespace Solution.Api.Controllers.Missao;

[ApiController]
[Route("api/v1/")]
[Authorize]
public class MissaoController : BaseController, IMissaoController
{
    private readonly IMissaoService _missaoService;

    public MissaoController(IMissaoService missaoService)
    {
        _missaoService = missaoService;
    }

    [HttpPost("iniciar-missao")]
    public async Task<IActionResult> IniciarMissao(MissaoRequest request)
    {
        
         var response= await _missaoService.IniciarMissao(request);
         return HandleResponse(response);
    }

    
    [HttpPost("finalizar-missao/{id}")]
    public async Task<IActionResult> FinalizarMissao(long id)
    {
        var response = await _missaoService.FinalizaMissao(id);
        return HandleResponse(response);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarMissoes()
    {
        var response = await _missaoService.BuscarMissoes();
        return HandleResponse(response);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> BuscarPorId(long id)
    {
        var response = await _missaoService.BuscarMissao(id);
        return HandleResponse(response);
    }

    [HttpGet("relatorio-inter-galactico")]
    public async Task<IActionResult> GerarRelatorioIntergalático()
    {
        var response = await _missaoService.RelatorioInterGalactico();
        return HandleResponse(response);
    }
}