using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record TripulanteResponse(long TripulanteId,string Nome,Patente Patente,Especialidade Especialidade);