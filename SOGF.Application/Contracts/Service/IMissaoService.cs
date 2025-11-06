using SOGF.Domain.Model;
using Solution.Application.Dto.Missao;

namespace Solution.Application.Contracts.Service;

public interface IMissaoService : IGenericService<Missao, MissaoRequest, MissaoResponse>
{
    
}