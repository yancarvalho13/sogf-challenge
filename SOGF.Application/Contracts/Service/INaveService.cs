using SOGF.Shared.Result;
using Solution.Application.Dto;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Contracts.Service;

public interface INaveService : IGenericService<SOGF.Domain.Model.Nave,NaveRequest,NaveResponse>
{
    Task<Result<string>> ResumoNave(long id);
}