using SOGF.Domain.Model;

namespace Solution.Application.Dto;

public record UserRequest(string username, string password, Role[] roles);