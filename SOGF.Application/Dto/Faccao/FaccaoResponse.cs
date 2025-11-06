using SOGF.Domain.Model;

namespace Solution.Application.Dto.Faccao;

public record FaccaoResponse(long id, string nome, StatusDiplomatico statusDiplomatico,  NivelAmeaca nivelAmeaca, List<NaveResponse> naves);