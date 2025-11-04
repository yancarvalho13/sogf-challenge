using Solution.Application.Contracts.Persistence;
using Solution.Application.Request;

namespace Solution.Application.Service.Nave;

public class NaveService : INaveService
{
    private readonly INaveRepository _naveRepository;

    public NaveService(INaveRepository naveRepository)
    {
        _naveRepository = naveRepository;
    }

  

    public async Task<Domain.Model.Nave> GetByIdAsync(long id)
    {
        var entity = await _naveRepository.GetByIdAsync(id);
        return entity;
        
    }

    public async Task<Domain.Model.Nave> CreateAsync(NaveRequest request)
    {
        var entity = new Domain.Model.Nave(request.nome, request.TipoNave, request.StatusOperacional);
        await _naveRepository.CreateAsync(entity);
        return entity;
    }

    public async Task<IReadOnlyCollection<Domain.Model.Nave>> GetAllAsync()
    {
        var naves = _naveRepository.GetAllAsync();
        
        return naves.Result;
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var entity = await _naveRepository.GetByIdAsync(id);

        if (entity is null) throw new NullReferenceException();
        await _naveRepository.DeleteAsync(entity);
        return true;
    }
}