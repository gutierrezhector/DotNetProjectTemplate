using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Application.Candidates;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Application.Mappers;

public class UserCreationCandidateMapper : Mapper<IUserCreationPayload, IUserCreationCandidate>
{
    public override IUserCreationCandidate Map(IUserCreationPayload from)
    {
        return new UserCreationCandidate
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}