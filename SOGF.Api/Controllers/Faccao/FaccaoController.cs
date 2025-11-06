using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Faccao;

namespace Solution.Api.Controllers.Faccao;

[ApiController]
[Route("api/v1/")]
public class FaccaoController(
    IFaccaoService faccaoService)
    : GenericController<SOGF.Domain.Model.Faccao, FaccaoRequest,FaccaoResponse>(faccaoService),
    IFaccaoController
{
    
}