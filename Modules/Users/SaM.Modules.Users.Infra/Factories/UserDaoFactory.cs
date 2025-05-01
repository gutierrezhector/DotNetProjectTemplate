using SaM.Core.Abstractions.Factories;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Infra.Factories;

public class UserDaoFactory : DaoFactory<UserDao, User, IUserUpdateCandidate>
{
    public override UserDao CreateFromEntity(User entity)
    {
        return new UserDao
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };
    }

    public override void UpdateFromCandidate(UserDao daoToUpdate, IUserUpdateCandidate updateCandidate)
    {
        daoToUpdate.FirstName = updateCandidate.FirstName;
        daoToUpdate.LastName = updateCandidate.LastName;
    }
}