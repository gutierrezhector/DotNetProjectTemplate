using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Ports.InBounds.Factories;

public interface IUserEntityFactory
{
    User Create(IUserCreationCandidate creationCandidate);
}