using SOGF.Domain.Model;
using SOGF.Shared.Result;

namespace Solution.Application.Contracts.Service;

public interface IGenericService<TEntity , TRequest, TResponse> 
{
    Task<Result<IReadOnlyCollection<TResponse>>> GetAllAsync();
    Task<Result<TResponse?>> GetByIdAsync(long id);
    Task<Result<TResponse>> CreateAsync(TRequest request);
    Task<Result<TResponse>> UpdateAsync(TRequest request, long id);
    Task<Result<bool>> DeleteAsync(long id);

    Task<PagedResult<TResponse>> GetAllByPageAsync(int page, int pageSize);
}