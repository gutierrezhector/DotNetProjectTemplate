using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Application.Candidates;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Application.Mappers;

public class UserUpdateCandidateMapper : Mapper<IUserUpdatePayload, IUserUpdateCandidate>
{
    public override IUserUpdateCandidate Map(IUserUpdatePayload from)
    {
        return new UserUpdateCandidate
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}