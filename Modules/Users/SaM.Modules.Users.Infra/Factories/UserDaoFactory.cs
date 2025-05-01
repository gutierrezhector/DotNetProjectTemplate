using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Infra.Factories;

public static class UserDaoFactory
{
    public static UserDao Create(User user)
    {
        return new UserDao
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }

    public static void Update(UserDao userDao, IUserUpdateCandidate updateCandidate)
    {
        userDao.FirstName = updateCandidate.FirstName;
        userDao.LastName = updateCandidate.LastName;
    }
}