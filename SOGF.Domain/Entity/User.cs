using SOGF.Domain.Model;

namespace SOGF.Domain.Entity;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public List<UserRoles> Roles { get; private set; }
    
    public string Salt { get; private set; }

    public User()
    {
    }

    public User(string username, string password, List<UserRoles> roles)
    {
        Username = username;
        Password = password;
        Roles = roles;
    }

    public User(string username, string password, List<UserRoles> roles, string salt)
    {
        Username = username;
        Password = password;
        Roles = roles;
        Salt = salt;
    }
}