using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Dto;
using Solution.Application.Service;
using Solution.Application.Service.Nave;

namespace Solution.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class NaveController : ControllerBase
{

    private readonly INaveService _naveService;

    public NaveController(INaveService naveService)
    {
        _naveService = naveService;
    }

    [HttpPost("/naves")]
    public async Task<IActionResult> Create([FromBody]CreateNaveRequest request)
    {
        try
        {
            await _naveService.CreateAsync(request);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost("/nave/adicionar-piloto/{pilotId}/{naveId}")]
    public async Task<IActionResult> EnlistPilot(long pilotId, long naveId)
    {
        try
        {
            var response = await _naveService.EnlistPilot(pilotId, naveId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost("/nave/adicionar-tripulante/{tripulanteId}/{naveId}")]
    public async Task<IActionResult> EnlistTripulante(long tripulanteId, long naveId)
    {
        try
        {
             await _naveService.EnlistTripulante(tripulanteId, naveId);
             return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("/naves/{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        
        try
        {
            var response = await _naveService.GetByIdAsync(id);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        } 
    }

    [HttpGet("/naves")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await _naveService.GetAllAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("/naves/{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        try
        {
            var response = await _naveService.DeleteByIdAsync(id);
            return response ? Ok() : BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    
}