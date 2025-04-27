using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Users.Domain.Mappers;

public class UserDaoToEntityMapper : Mapper<UserDao, IUser>
{
    public override IUser Map(UserDao from)
    {
        return new User
        {
             Id = from.Id,
             FirstName = from.FirstName,
             LastName = from.LastName,
        };
    }
}