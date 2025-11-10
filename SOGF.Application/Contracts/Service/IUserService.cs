using SOGF.Domain.Entity;
using SOGF.Domain.Entity.Result;
using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Application.Contracts.Service;

public interface IUserService: IGenericService<User, UserRequest, UserResponse>
{
    Task<Result<string>> Login(UserLoginRequest request);
    Task<Result<UserResponse>> Register(UserRequest request);
}