using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Web.Abstractions;

public interface IUsersApplication
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(UserCreationCandidate creationCandidate);
    Task<User> UpdateAsync(int id, UserUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}