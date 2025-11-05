namespace Solution.Application.Contracts.Mapping;

public interface IMapper<TEntity, TRequest, TResponse>
{
 TEntity ToEntity(TRequest request);
 TResponse ToDto(TEntity entity);
}