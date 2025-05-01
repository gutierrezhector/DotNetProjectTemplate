using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Ports.InBounds.Applications;

public interface IUsersApplication
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(IUserCreationPayload creationPayload);
    Task<User> UpdateAsync(int id, IUserUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}