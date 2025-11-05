using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;

namespace Solution.Api.Contracts;

public interface IGenericController<TEntity,TRequest, TResponse> 
{
    Task<IActionResult> Create(TRequest request);
    Task<IActionResult> GetAll();
    Task<IActionResult> GetById(long id);
    Task<IActionResult> Update(TRequest request, long id);
    Task<IActionResult> DeleteById(long id);
    
}