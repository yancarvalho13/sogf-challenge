using SOGF.Domain.Entity.Result;
using SOGF.Domain.Model;
using Solution.Application.Dto.LlmAdapter;
using Solution.Application.Dto.Missao;

namespace Solution.Application.Contracts.Service;

public interface IMissaoService
{
    Task<Result<MissaoResponse>> IniciarMissao(MissaoRequest request);
    Task<Result<List<MissaoResponse>>> BuscarMissoes();

    Task<Result<MissaoResponse>> BuscarMissao(long id);
    Task<Result<MissaoResponse>> FinalizaMissao(long id);

    Task<Result<string>> RelatorioInterGalactico();

}