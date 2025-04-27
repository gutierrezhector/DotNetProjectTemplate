using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Factories;

namespace SaM.Modules.Users.Domain.Factories;

public class UserEntityFactory : IUserEntityFactory
{
    public IUser Create(IUserCreationCandidate creationCandidate)
    {
        return new User
        {
            FirstName = creationCandidate.FirstName,
            LastName = creationCandidate.LastName,
        };
    }
}