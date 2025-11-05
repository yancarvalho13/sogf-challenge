using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;

namespace Solution.Api.Contracts;

public interface IGenericController<T> where T : BaseModel
{
    Task<IActionResult> Create(T request);
    Task<IActionResult> GetAll();
    Task<IActionResult> GetById(long id);
    Task<IActionResult> Update(T request, long id);
    Task<IActionResult> DeleteById(long id);
    
}