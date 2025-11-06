using SOGF.Domain.Model;

namespace Solution.Application.Dto.Faccao;

public record FaccaoRequest(string nome,
    StatusDiplomatico statusDiplomatico,
    NivelAmeaca nivelAmeaca);