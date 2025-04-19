using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Users.Ports.InBounds;

public interface IUsersRepository
{
    Task<User> GetByIdAsync(int userId);
    Task<User> CreateAsync(User user);
}