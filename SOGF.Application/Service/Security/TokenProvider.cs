using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SOGF.Domain;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Security;
using Solution.Application.Dto;

namespace Solution.Application.Service.Security;

public class TokenProvider : ITokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }



    private ClaimsIdentity GenerateClaims(SOGF.Domain.Entity.User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(
            new Claim(ClaimTypes.Name, user.Username));
        foreach (var role in user.Roles)
        {
            string roleName = role.Role.ToString();
            ci.AddClaim(new Claim(ClaimTypes.Role, roleName));
        }
    
        return ci;
    }

    public string GenerateToken(SOGF.Domain.Entity.User user)
    {
         
        var securityKey = _configuration["Jwt:Secret"];
        var secretKey = Encoding.ASCII.GetBytes(securityKey);
        var handler = new JwtSecurityTokenHandler();

        var credentials = 
            new SigningCredentials(new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
            
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}