using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record TripulanteRequest(string nome, Patente patente, Especialidade especialidade);