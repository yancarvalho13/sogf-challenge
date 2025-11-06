using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Missao;

namespace Solution.Api.Controllers.Missao;

[ApiController]
[Route("api/v1/")]
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
         return response.isSuccess ? Ok(response) : Problem(response.Error);
        
    }

    
    [HttpPost("finalizar-missao/{id}")]
    public async Task<IActionResult> FinalizarMissao(long id)
    {
        var response = await _missaoService.FinalizaMissao(id);
        return response.isSuccess ? Ok(response) : Problem(response.Error);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarMissoes()
    {
        var response = await _missaoService.BuscarMissoes();
        return Ok(response);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> BuscarPorId(long id)
    {
        var response = await _missaoService.BuscarMissao(id);
        return response.isSuccess ? Ok(response) : Problem(response.Error);
    }
}