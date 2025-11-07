using Microsoft.AspNetCore.Mvc;
using Solution.Api.Contracts;
using Solution.Api.Controllers.Common;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Service.Tripulante;

namespace Solution.Api.Controllers.Tripulante;

[ApiController]
[Route("api/v1/")]
public class TripulanteController(ITripulanteService tripulanteService)
    : GenericController<SOGF.Domain.Model.Tripulante, TripulanteRequest, TripulanteResponse>(tripulanteService),
        ITripulanteController
{
    private readonly ITripulanteService _tripulanteService = tripulanteService;

   
}