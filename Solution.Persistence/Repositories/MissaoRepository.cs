using Solution.Application.Contracts.Persistence;
using Solution.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class MissaoRepository : GenericRepository<Missao>, IMissaoRepository
{
    public MissaoRepository(SogfDbContext context) : base(context)
    {
    }
}