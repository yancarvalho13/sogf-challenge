
using Solution.Domain.Model;

namespace Solution.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseModel
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(long id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}