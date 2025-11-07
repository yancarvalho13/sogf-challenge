using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record UserResponse(string username, List<Role> roles);