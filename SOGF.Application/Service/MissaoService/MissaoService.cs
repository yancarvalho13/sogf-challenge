using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto.Missao;

namespace Solution.Application.Service.MissaoService;

public class MissaoService(IMissaoRepository missaoRepository,
    IMissaoMapper missaoMapper)
: GenericService<Missao, MissaoRequest, MissaoResponse>(missaoRepository, missaoMapper),
    IMissaoService
{
    
}