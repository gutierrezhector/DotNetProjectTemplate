namespace SaM.Modules.Users.Web.Candidates;

public record UserCreationCandidate
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}