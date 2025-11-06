using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;

namespace Solution.Api.Controllers;

[ApiController]
public class GenericController<TEntity, TRequest, TResponse>(
    IGenericService<TEntity, TRequest, TResponse> genericService)
    : BaseController,
        IGenericController<TEntity, TRequest, TResponse>

{
    [HttpPost("[controller]")]
    public async Task<IActionResult> Create(TRequest request)
    {
        try
        {
            var response = await genericService.CreateAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("[controller]")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var response = await genericService.GetAllAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("[controller]/{id}")]    
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var response = await genericService.GetByIdAsync(id);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete("[controller]/{id}")]
    public async Task<IActionResult> Update(TRequest request, long id)
    {
        try
        {
            var response = await genericService.UpdateAsync(request, id);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete("[controller]/{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        try
        {
            var response = await genericService.DeleteAsync(id);
            return response ? Ok() : BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}