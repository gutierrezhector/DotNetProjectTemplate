using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Users.Infra.Factories;

public static class UserDaoFactory
{
    public static UserDao Create(IUser user)
    {
        return new UserDao
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}