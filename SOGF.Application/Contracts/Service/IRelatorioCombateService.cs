using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Contracts.Service;

public interface IRelatorioCombateService
{
    Task<Result<RelatorioCombateResponse>> IniciarCombate();

    Task<Result<HistoricoCombateResponse>> BuscarRelatorioPiloto(long id);
    Task<Result<HistoricoCombateResponse>> BuscarRelatorioFaccao(long id);

}