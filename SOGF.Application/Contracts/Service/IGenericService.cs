using SOGF.Domain.Model;

namespace Solution.Application.Contracts.Service;

public interface IGenericService<TEntity , TRequest, TResponse> 
{
    Task<List<TResponse>> GetAllAsync();
    Task<TResponse?> GetByIdAsync(long id);
    Task<TResponse> CreateAsync(TRequest request);
    Task<TResponse> UpdateAsync(TRequest request, long id);
    Task<bool> DeleteAsync(long id);
}