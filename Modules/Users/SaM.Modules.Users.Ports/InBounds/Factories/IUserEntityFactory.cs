using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Users.Ports.InBounds.Factories;

public interface IUserEntityFactory
{
    IUser Create(IUserCreationCandidate creationCandidate);
}