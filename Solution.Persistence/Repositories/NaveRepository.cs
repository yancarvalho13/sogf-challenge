using Solution.Application.Contracts.Persistence;
using Solution.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class NaveRepository : GenericRepository<Nave>, INaveRepository
{
    public NaveRepository(SogfDbContext context) : base(context)
    {
        
    }
}