using SOGF.Domain.Entity.Result;
using SOGF.Domain.Model;

namespace Solution.Application.Contracts.Service;

public interface IGenericService<TEntity , TRequest, TResponse> 
{
    Task<Result<List<TResponse>>> GetAllAsync();
    Task<Result<TResponse?>> GetByIdAsync(long id);
    Task<Result<TResponse>> CreateAsync(TRequest request);
    Task<Result<TResponse>> UpdateAsync(TRequest request, long id);
    Task<Result<bool>> DeleteAsync(long id);

    Task<PagedResult<TResponse>> GetAllByPageAsync(int page, int pageSize);
}