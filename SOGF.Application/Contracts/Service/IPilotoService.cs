using SOGF.Domain.Model;
using SOGF.Shared.Result;
using Solution.Application.Dto.Piloto;

namespace Solution.Application.Contracts.Service;

public interface IPilotoService : IGenericService<Piloto, PilotoRequest, PilotoResponse>
{
    Task<Result<string>> ResumoPiloto(long id);
}