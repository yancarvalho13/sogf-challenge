using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class TripulanteRepository : GenericRepository<Tripulante>, ITripulanteRepository
{
    public TripulanteRepository(SogfDbContext context) : base(context)
    {
    }
}