using System.Security.Cryptography;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using SOGF.Domain;
using SOGF.Domain.Entity.Result;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Security;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Validations;

namespace Solution.Application.Service.User;

public class UserService(
    IUserRepository userRepository,
    ITokenProvider tokenProvider,
    IUserMapper mapper2,
    UserRequestValidator validator)
    : GenericService<SOGF.Domain.Entity.User, UserRequest, UserResponse>(userRepository, mapper2, validator), IUserService
{
    public async Task<Result<string>> Login(UserLoginRequest request)
    {
        var user = await userRepository.FindByUsername(request.username);
        var requestPassword = HashPassword(request.password, user.Salt);
        if (!requestPassword.Equals(user.Password)) return Errors.InvalidCredentials;
        var token = tokenProvider.GenerateToken(user);
        return token;
    }

    public async Task<Result<UserResponse>> Register(UserRequest request)
    {
        var isValid = await validator.ValidateAsync(request);
        var validationErrors =  ValidateRequest(isValid);
        if (validationErrors.Count != 0) return validationErrors;

        var salt = GenerateSalt();
        
        var hashPassword = HashPassword(request.password, salt);
        var user = new SOGF.Domain.Entity.User(request.username, hashPassword,
            request.roles.Select(r => new UserRoles(r)).ToList(),salt );
        await userRepository.CreateAsync(user);

        return mapper2.ToDto(user);
    }

    private string HashPassword(string passwordRequest, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: passwordRequest!,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
        ));

        return hash;
    }

    private string GenerateSalt()
    {
        var salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return Convert.ToBase64String(salt);
    }
    private List<ValidationFailureResponse> ValidateRequest(ValidationResult validationResult)
    {
        return validationResult.IsValid
            ? new List<ValidationFailureResponse>()
            : validationResult.Errors.Select(e =>
                new ValidationFailureResponse(e.PropertyName, e.ErrorMessage, e.AttemptedValue.ToString())).ToList();

    }
}