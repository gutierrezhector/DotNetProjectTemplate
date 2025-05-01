using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Users.Domain.Mappers;

public class UserDaoToUserEntityMapper : Mapper<UserDao, User>
{
    public override User MapNonNullable(UserDao from)
    {
        return new User
        {
            Id = from.Id,
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}