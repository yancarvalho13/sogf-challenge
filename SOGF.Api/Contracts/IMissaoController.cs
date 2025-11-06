using SOGF.Domain.Model;
using Solution.Application.Dto.Missao;

namespace Solution.Api.Contracts;

public interface IMissaoController
    : IGenericController<Missao, MissaoRequest, MissaoResponse>
{
    
}