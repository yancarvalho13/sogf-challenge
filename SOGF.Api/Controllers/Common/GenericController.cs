using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;

namespace Solution.Api.Controllers.Common;

[ApiController]
public class GenericController<TEntity, TRequest, TResponse>(
    IGenericService<TEntity, TRequest, TResponse> genericService)
    : BaseController,
        IGenericController<TEntity, TRequest, TResponse>

{
    [HttpPost("[controller]")]
    [Authorize]
    public async Task<IActionResult> Create(TRequest request)
    {

            var response = await genericService.CreateAsync(request);
            return HandleResponse(response);


    }

    [HttpGet("[controller]")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        
            var response = await genericService.GetAllAsync();
            return HandleResponse(response);
        
    }

    [HttpGet("[controller]/{id}")]    
    [Authorize]
    public async Task<IActionResult> GetById(long id)
    {
            var response = await genericService.GetByIdAsync(id);
            return HandleResponse(response);
    }

    [HttpPatch("[controller]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(TRequest request, long id)
    {
            var response = await genericService.UpdateAsync(request, id);
            return HandleResponse(response);
    }

    [HttpDelete("[controller]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteById(long id)
    {
        
            var response = await genericService.DeleteAsync(id);
            return HandleResponse(response);
    }
}