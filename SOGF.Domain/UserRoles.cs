using SOGF.Domain.Model;

namespace SOGF.Domain;

public class UserRoles : BaseEntity
{
    public long Id { get; set; }
    public Role Role { get; set; }
    


    public UserRoles()
    {
    }

    public UserRoles(Role role)
    {
        Role = role;
    }
}