using Microsoft.AspNetCore.Mvc;
using Solution.Application.Dto;
using Solution.Application.Service.Tripulante;

namespace Solution.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class TripulanteController : ControllerBase
{
    private readonly ITripulanteService _tripulanteService;

    
    public TripulanteController(ITripulanteService tripulanteService)
    {
        _tripulanteService = tripulanteService;
    }

    [HttpPost("/tripulantes")]
    public async Task<IActionResult> Create([FromBody] TripulanteRequest request)
    {
        try
        {
            var response = await _tripulanteService.CreateAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("/tripulantes/{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var response = await _tripulanteService.GetByIdAsync(id);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("/tripulantes")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await _tripulanteService.GetAllAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    
    

    
}