using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Application.Candidates;

public record UserUpdateCandidate : IUserUpdateCandidate
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}