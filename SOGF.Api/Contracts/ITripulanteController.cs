using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Api.Contracts;

public interface ITripulanteController : IGenericController<Tripulante, TripulanteRequest, TripulanteResponse>
{
}