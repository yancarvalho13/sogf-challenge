using FluentValidation;
using FluentValidation.Results;
using SOGF.Domain;
using SOGF.Domain.Entity.Result;
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
    private readonly AbstractValidator<TRequest> _validator;

    public GenericService(IGenericRepository<TEntity> genericRepository, IMapper<TEntity, TRequest, TResponse> mapper, AbstractValidator<TRequest> validator)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<List<TResponse>>> GetAllAsync()
    {
        var entities = await _genericRepository.GetAllAsync();
        if (entities.Count == 0) return new List<TResponse>();
        var responseList =
            entities.Select(e => _mapper.ToDto(e)).ToList();

        return responseList;
    }

    public async Task<Result<TResponse?>> GetByIdAsync(long id)
    {
        var entitie = await _genericRepository.GetByIdAsync(id);
        if (entitie is null) return Errors.RecurseNotFound;

        return _mapper.ToDto(entitie);
    }

    public async Task<Result<TResponse>> CreateAsync(TRequest request)
    {
        var isValid = await _validator.ValidateAsync(request);
        var validationErrors =  ValidateRequest(isValid);
        if (ValidateRequest(isValid).Count != 0) return validationErrors;
        
         var entitie = _mapper.ToEntity(request);
         await _genericRepository.CreateAsync(entitie);
         return _mapper.ToDto(entitie);
    }

    public async Task<Result<TResponse>> UpdateAsync(TRequest request, long id)
    {
        var isValid = await _validator.ValidateAsync(request);
        var validationErrors =  ValidateRequest(isValid);
        if (validationErrors.Count != 0) return validationErrors;
        
        var entitie = _mapper.ToEntity(request);
        await _genericRepository.UpdateAsync(entitie);
        return _mapper.ToDto(entitie);
    }

    public async Task<Result<bool>> DeleteAsync(long id)
    {
        var entitie = await _genericRepository.GetByIdAsync(id);
        if (entitie is null) return Errors.RecurseNotFound;
        await _genericRepository.DeleteAsync(entitie);
        return true;
    }

    public async Task<PagedResult<TResponse>> GetAllByPageAsync(int page, int pageSize)
    {

        if (page == 0) page = 1;
        var totalRecords = await _genericRepository.GetTotalRecords();
        var totalPages = totalRecords / pageSize;
        var list = await _genericRepository.GetAllByPageAsync(page, pageSize);

        var responseList = list.Select(x => _mapper.ToDto(x));
        
        return new PagedResult<TResponse>(responseList,
            true, page, responseList.Count(), totalRecords, totalPages);
    }


    private List<ValidationFailureResponse> ValidateRequest(ValidationResult validationResult)
    {

        return validationResult.IsValid
            ? new List<ValidationFailureResponse>()
            : validationResult.Errors.Select(e =>
                new ValidationFailureResponse(e.PropertyName, e.ErrorMessage, e.AttemptedValue.ToString())).ToList();

    }
}