using SaM.Modules.Users.Domain.Entities;

namespace SaM.Database.Core.Daos.Users;

public class UserDao
{
    public int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public void UpdateFromDomainEntity(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
}