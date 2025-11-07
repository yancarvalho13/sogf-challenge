using Microsoft.EntityFrameworkCore;
using SOGF.Domain.Entity;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Persistence;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly SogfDbContext _context;
    public UserRepository(SogfDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> FindByUsername(string username)
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }
}