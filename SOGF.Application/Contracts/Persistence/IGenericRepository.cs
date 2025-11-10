
using SOGF.Domain.Entity.Result;
using SOGF.Domain.Model;

namespace Solution.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(long id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

    Task<IReadOnlyList<T>> GetAllByPageAsync(int page, int pagesize);

    Task<long> GetTotalRecords();
}