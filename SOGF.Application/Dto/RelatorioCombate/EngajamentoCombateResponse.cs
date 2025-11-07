using SOGF.Domain.Model;

namespace Solution.Application.Dto.RelatorioCombate;

public record EngajamentoCombateResponse(long naveId, 
    long pilotoId,
    long relatorioCombateId,
    ResultadoCombate resultadoCombate);