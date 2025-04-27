using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Ports.InBounds.Applications;

public interface IUsersApplication
{
    Task<IUser> GetByIdAsync(int id);
    Task<IUser> CreateAsync(IUserCreationPayload creationPayload);
    Task<IUser> UpdateAsync(int id, IUserUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}