using SOGF.Domain.Entity.Enum;
using SOGF.Domain.Model;

namespace Solution.Application.Dto.RelatorioCombate;

public record RelatorioCombateResponse(long id,
    DateTime data,
    ResultadoCombate resultadoCombate,
    string descricaoTatica,
    long faccaoVencedoraId,
    List<EngajamentoCombateResponse> engajamentoCombate);