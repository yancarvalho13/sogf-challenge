using SOGF.Domain.Entity;
using SOGF.Domain.Model;

namespace Solution.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> FindByUsername(string username);
}