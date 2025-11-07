using SOGF.Domain.Entity;
using SOGF.Domain.Model;
using Solution.Application.Dto;

namespace Solution.Application.Contracts.Security;


public interface ITokenProvider
{
        public string GenerateToken(User user);
}