using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Users.Infra.Mappers;

public class UserFromDaoMapper : Mapper<UserDao, User>
{
    public override User Map(UserDao from)
    {
        return new User
        {
             Id = from.Id,
             FirstName = from.FirstName,
             LastName = from.LastName,
        };
    }
}