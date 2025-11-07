using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Api.Contracts;

public interface INaveController : IGenericController<Nave, NaveRequest, NaveResponse>
{
    Task<IActionResult> ResumoNave(long id);
}