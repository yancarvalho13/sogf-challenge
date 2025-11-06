using SOGF.Domain.Model;

namespace Solution.Application.Dto.Missao;

public record MissaoRequest(ObjetivoMissao objetivoMissao,
    SetorGalatico setorGalatico,
    long naveId,
    long pilotoId,
    List<long> tripulantesId);