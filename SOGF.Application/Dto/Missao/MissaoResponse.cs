using SOGF.Domain.Model;

namespace Solution.Application.Dto.Missao;

public record MissaoResponse(long id,
    ObjetivoMissao objetivoMissao,
    SetorGalatico setorGalatico,
    StatusMissao statusMissao,
    long naveId,
    long pilotoId,
    List<MissaoTripulanteResponse> tripulantesId);