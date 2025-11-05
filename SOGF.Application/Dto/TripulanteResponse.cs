using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record TripulanteResponse(long tripulanteId, string nome, Patente Patente, Especialidade Especialidade);