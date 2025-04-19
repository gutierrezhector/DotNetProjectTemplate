using SaM.Core.Abstractions.Mappers;
using SaM.Database.Data.Daos.Users;
using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Users.Infra.Mappers;

public class UserMapper : Mapper<UserDao, User>
{
    public override User Map(UserDao dao)
    {
        return new User
        {
             Id = dao.Id,
             FirstName = dao.FirstName,
             LastName = dao.LastName,
        };
    }
}