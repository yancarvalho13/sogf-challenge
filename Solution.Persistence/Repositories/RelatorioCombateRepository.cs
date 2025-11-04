using Solution.Application.Contracts.Persistence;
using Solution.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class RelatorioCombateRepository : GenericRepository<RelatorioCombate>, IRelatorioCombateRepository
{
    public RelatorioCombateRepository(SogfDbContext context) : base(context)
    {
    }
}