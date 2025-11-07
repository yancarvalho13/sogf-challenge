using SOGF.Domain.Entity;
using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Application.Contracts.Mapping;

public interface IUserMapper : IMapper<User, UserRequest, UserResponse>
{
    
}