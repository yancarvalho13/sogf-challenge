using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Request;
using Solution.Application.Service;
using Solution.Application.Service.Nave;

namespace Solution.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NaveController : ControllerBase
{

    private readonly INaveService _naveService;

    public NaveController(INaveService naveService)
    {
        _naveService = naveService;
    }


    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NaveRequest request)
    {
        try
        {
            var entity = await _naveService.CreateAsync(request);
            return Ok(entity);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("{id}")]
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

    [HttpGet]
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

    [HttpDelete("{id}")]
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