using Solution.Application.Request;

namespace Solution.Application.Service.Nave;

public interface INaveService
{
    Task<Domain.Model.Nave> GetByIdAsync(long id);
    Task<Domain.Model.Nave> CreateAsync(NaveRequest request);

    Task<IReadOnlyCollection<Domain.Model.Nave>> GetAllAsync();

    Task<Boolean> DeleteByIdAsync(long id);
}