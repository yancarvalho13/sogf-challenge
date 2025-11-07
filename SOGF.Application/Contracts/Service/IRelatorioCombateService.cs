using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Contracts.Service;

public interface IRelatorioCombateService
{
    Task<Result<RelatorioCombateResponse>> IniciarCombate();
}