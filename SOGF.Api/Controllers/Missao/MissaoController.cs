using Solution.Api.Contracts;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Missao;

namespace Solution.Api.Controllers.Missao;

public class MissaoController(IMissaoService missaoService)
: GenericController<SOGF.Domain.Model.Missao, MissaoRequest, MissaoResponse>(missaoService),
    IMissaoController
{
    
}