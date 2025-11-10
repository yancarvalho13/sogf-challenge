using SOGF.Domain.Model;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Contracts.Mapping;

public interface IFaccaoMapper : IMapper<Faccao, FaccaoRequest, FaccaoResponse>
{
}