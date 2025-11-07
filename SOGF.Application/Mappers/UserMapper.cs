using SOGF.Domain;
using SOGF.Domain.Entity;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public class UserMapper : IUserMapper
{
    public User ToEntity(UserRequest request) => new User(request.username, request.password,
            request.roles.Select(r => new UserRoles(r)).ToList());
    

    public UserResponse ToDto(User entity) => new UserResponse(entity.Username,
            entity.Roles.Select(r => r.Role).ToList());
    
}