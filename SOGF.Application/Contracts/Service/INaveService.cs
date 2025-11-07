using Solution.Application.Dto;

namespace Solution.Application.Contracts.Service;

public interface INaveService : IGenericService<SOGF.Domain.Model.Nave,NaveRequest,NaveResponse>
{
    Task<Result<string>> ResumoNave(long id);
}