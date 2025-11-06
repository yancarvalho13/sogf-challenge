using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;

namespace Solution.Application.Service;

public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> 
where TEntity : BaseEntity 
{
    private readonly IGenericRepository<TEntity> _genericRepository;
    private readonly IMapper<TEntity, TRequest, TResponse> _mapper;

    public GenericService(IGenericRepository<TEntity> genericRepository, IMapper<TEntity, TRequest, TResponse> mapper)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
    }

    public async Task<List<TResponse>> GetAllAsync()
    {
        var entities = await _genericRepository.GetAllAsync();
        if (entities.Count == 0) return new List<TResponse>();
        var responseList =
            entities.Select(e => _mapper.ToDto(e)).ToList();

        return responseList;
    }

    public async Task<TResponse?> GetByIdAsync(long id)
    {
        var entitie = await _genericRepository.GetByIdAsync(id);
        if (entitie is null) throw new NullReferenceException();

        return _mapper.ToDto(entitie);
    }

    public async Task<TResponse> CreateAsync(TRequest request)
    {
         var entitie = _mapper.ToEntity(request);
         await _genericRepository.CreateAsync(entitie);
         return _mapper.ToDto(entitie);
    }

    public async Task<TResponse> UpdateAsync(TRequest request, long id)
    {
        var entitie = _mapper.ToEntity(request);
        await _genericRepository.UpdateAsync(entitie);
        return _mapper.ToDto(entitie);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entitie = await _genericRepository.GetByIdAsync(id);
        if (entitie is null) return false;
        await _genericRepository.DeleteAsync(entitie);
        return true;
    }
}