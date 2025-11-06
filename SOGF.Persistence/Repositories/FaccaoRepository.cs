using SOGF.Domain.Model;
using Solution.Application.Contracts.Persistence;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class FaccaoRepository(SogfDbContext context)
    : GenericRepository<Faccao>(context), IFaccaoRepository;