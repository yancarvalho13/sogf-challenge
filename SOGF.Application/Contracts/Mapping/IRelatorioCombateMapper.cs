using SOGF.Domain.Model;
using Solution.Application.Dto.RelatorioCombate;

namespace Solution.Application.Contracts.Mapping;

public interface IRelatorioCombateMapper
{
    RelatorioCombateResponse ToDto(RelatorioCombate entity);

}