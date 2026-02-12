using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Application.Candidates;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Application.Mappers;

public class UserCreationPayloadToUserCreationCandidateMapper : Mapper<IUserCreationPayload, IUserCreationCandidate>
{
    public override IUserCreationCandidate MapNonNullable(IUserCreationPayload from)
    {
        return new UserCreationCandidate
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}