using SOGF.Domain.Model;

namespace Solution.Application.Dto.Piloto;

public record PilotoResponse(long id, string nome, Patente patente);