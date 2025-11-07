using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Application.Dto.Piloto;

namespace Solution.Api.Contracts;

public interface IPilotoController : IGenericController<Piloto, PilotoRequest, PilotoResponse>
{
    Task<IActionResult> ResumoPiloto(long id);
}