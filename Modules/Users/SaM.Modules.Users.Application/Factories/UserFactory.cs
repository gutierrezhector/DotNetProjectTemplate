using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application.Factories;

public static class UserFactory
{
    public static User Create(UserCreationCandidate creationCandidate)
    {
        return new User
        {
            FirstName = creationCandidate.FirstName,
            LastName = creationCandidate.LastName,
        };
    }
}