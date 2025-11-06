using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class TripulanteRepository(SogfDbContext context)
    : GenericRepository<Tripulante>(context), ITripulanteRepository;