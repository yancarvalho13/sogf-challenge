using SOGF.Domain.Model;

namespace Solution.Application.Contracts.Persistence;

public interface IMissaoRepository : IGenericRepository<Missao>
{
    Task<List<Missao>> GetMissoesEmAndamento();
}