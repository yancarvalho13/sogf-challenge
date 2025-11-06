using Microsoft.EntityFrameworkCore;
using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly SogfDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(SogfDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}