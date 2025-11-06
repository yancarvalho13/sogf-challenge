using Microsoft.AspNetCore.Mvc;
using SOGF.Domain.Model;
using Solution.Application.Dto.Missao;

namespace Solution.Api.Contracts;

public interface IMissaoController
{
    Task<IActionResult> IniciarMissao(MissaoRequest request);

    Task<IActionResult> BuscarMissoes();

    Task<IActionResult> BuscarPorId(long id);
}