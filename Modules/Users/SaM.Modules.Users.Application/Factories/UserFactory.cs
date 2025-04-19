using SaM.Modules.Users.Ports.OutBounds.Models;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application.Factories;

public static class UserFactory
{
    public static User Create(UserCandidate candidate)
    {
        return new User
        {
            FirstName = candidate.FirstName,
            LastName = candidate.LastName,
        };
    }
}