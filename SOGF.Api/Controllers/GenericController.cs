using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Api.Contracts;

namespace Solution.Api.Controllers;

public class GenericController<T> : IGenericController<T> where T : BaseModel
{
    
    
    public async Task<IActionResult> Create(T request)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Update(T request, long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteById(long id)
    {
        throw new NotImplementedException();
    }
}