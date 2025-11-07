using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Api.Controllers.Common;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Service.Nave;

namespace Solution.Api.Controllers.Nave;

[ApiController]
[Route("api/v1/")]
public class NaveController(INaveService naveService)
    : GenericController<SOGF.Domain.Model.Nave, NaveRequest, NaveResponse>(naveService), INaveController
{ }