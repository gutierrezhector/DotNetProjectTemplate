using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Users.Domain.Factories;

public class UserEntityFromDaoFactory(
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFromDaoFactory<User, UserDao>
{
    public override User CreateFromDao(UserDao from)
    {
        return userDaoToUserEntityMapper.MapNonNullable(from);
    }
}
