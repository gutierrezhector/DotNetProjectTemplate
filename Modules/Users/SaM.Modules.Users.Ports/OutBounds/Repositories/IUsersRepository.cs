using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Ports.OutBounds.Repositories;

public interface IUsersRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(int id, IUserUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
    Task<bool> ExistAsync(int userId);
    Task<bool> IsUserLinkedToTeacherAsync(int userId);
    Task<bool> IsUserLinkedToStudentAsync(int userId);
}