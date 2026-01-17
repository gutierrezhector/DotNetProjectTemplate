using SaM.Modules.Users.Ports.InBounds.Services;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Users.Domain.Services;

public class UserDeletableService(
    IUsersRepository usersRepository
) : IUserDeletableService
{
    public async Task<bool> IsUserDeletableAsync(int userId)
    {
        if (await usersRepository.IsUserLinkedToTeacherAsync(userId) ||  await usersRepository.IsUserLinkedToStudentAsync(userId))
        {
            return false;
        }

        return true;
    }
}