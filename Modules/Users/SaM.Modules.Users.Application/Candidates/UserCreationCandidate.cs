using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Application.Candidates;

public record UserCreationCandidate : IUserCreationCandidate
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}