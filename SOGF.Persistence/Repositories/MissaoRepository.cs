using Microsoft.EntityFrameworkCore;
using Solution.Application.Contracts.Persistence;
using SOGF.Domain.Model;
using Solution.Persistence.Contexts;

namespace Solution.Persistence.Repositories;
public class MissaoRepository: GenericRepository<Missao>,IMissaoRepository
{
    private readonly SogfDbContext _context;
    public MissaoRepository(SogfDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Missao>> GetMissoesEmAndamento()
    {
        var response = await _context.Missoes.AsNoTracking().Where(m => m.StatusMissao.Equals(StatusMissao.EmAndamento)).ToListAsync();
        return response;
    }
}