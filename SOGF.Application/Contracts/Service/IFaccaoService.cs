using SOGF.Domain.Model;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Contracts.Service;

public interface IFaccaoService
    : IGenericService<Faccao,FaccaoRequest, FaccaoResponse>
{
}