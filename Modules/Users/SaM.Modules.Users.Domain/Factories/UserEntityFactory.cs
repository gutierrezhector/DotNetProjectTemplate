using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain.Factories;

public class UserEntityFactory(
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFactory<User, UserDao, IUserCreationCandidate>
{
    public override User CreateFromCandidate(IUserCreationCandidate creationCandidate)
    {
        return new User
        {
            FirstName = creationCandidate.FirstName,
            LastName = creationCandidate.LastName,
        };
    }

    public override User CreateFromDao(UserDao from)
    {
        return userDaoToUserEntityMapper.MapNonNullable(from);
    }
}