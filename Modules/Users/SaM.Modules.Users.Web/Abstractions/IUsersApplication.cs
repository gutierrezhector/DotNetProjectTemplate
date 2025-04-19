using SaM.Modules.Users.Ports.OutBounds.Models;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Web.Abstractions;

public interface IUsersApplication
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(UserCandidate candidate);
}