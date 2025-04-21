using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Users.Ports.InBounds;

public interface IUsersRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(int id);
}