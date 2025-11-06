using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;

public class RelatorioCombateRepository(SogfDbContext context)
    : GenericRepository<RelatorioCombate>(context), IRelatorioCombateRepository;