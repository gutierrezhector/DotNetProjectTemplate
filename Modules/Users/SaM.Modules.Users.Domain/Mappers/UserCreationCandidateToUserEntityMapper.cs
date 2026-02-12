using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain.Mappers;

public class UserCreationCandidateToUserEntityMapper : Mapper<IUserCreationCandidate, User>
{
    public override User MapNonNullable(IUserCreationCandidate from)
    {
        return new User
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}