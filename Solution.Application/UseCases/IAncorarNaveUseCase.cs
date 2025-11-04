using Solution.Application.TransferObjects.Nave;

namespace Solution.Application.UseCases;

public interface IAncorarNaveUseCase
{
    Task<AncorarNaveResponse> AncorarNave(AncorarNaveRequest request);
}