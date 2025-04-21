namespace SaM.Modules.Users.Web.Candidates;

public record UserUpdateCandidate
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}