using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Users.Ports.OutBounds.Repositories;

public interface IUsersRepository
{
    Task<IUser> GetByIdAsync(int id);
    Task<IUser> CreateAsync(IUser user);
    Task<IUser> UpdateAsync(int id, IUserUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}