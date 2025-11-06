using SOGF.Domain.Model;

namespace Solution.Application.Dto.Piloto;

public record PilotoRequest(string nome, Patente patente);