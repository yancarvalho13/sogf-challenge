using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class NaveRepository(SogfDbContext context)
    : GenericRepository<Nave>(context), INaveRepository;