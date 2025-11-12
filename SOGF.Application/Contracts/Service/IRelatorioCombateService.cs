using SOGF.Domain.Entity.Result;
using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Contracts.Service;

public interface IRelatorioCombateService
{
    Task<Result<RelatorioCombateResponse>> IniciarCombate();

    Task<Result<IEnumerable<RelatorioCombateResponse>>> GetAllAsync();
    Task<Result<HistoricoCombateResponse>> BuscarRelatorioPiloto(long id);
    Task<Result<HistoricoCombateResponse>> BuscarRelatorioFaccao(long id);

}