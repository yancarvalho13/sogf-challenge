using SOGF.Domain.Model;
using Solution.Application.Dto.Faccao;

namespace Solution.Api.Contracts;

public interface IFaccaoController :
    IGenericController<Faccao, FaccaoRequest, FaccaoResponse>
{
    
}