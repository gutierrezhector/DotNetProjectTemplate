using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain.Factories;

public class UserEntityFromCandidateFactory(
    Mapper<IUserCreationCandidate, User> userCreationCandidateToUserEntityMapper
) : EntityFromCandidateFactory<User, IUserCreationCandidate>
{
    public override User CreateFromCandidate(IUserCreationCandidate creationCandidate)
    {
        return userCreationCandidateToUserEntityMapper.MapNonNullable(creationCandidate);
    }
}
