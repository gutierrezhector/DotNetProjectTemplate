namespace SaM.Modules.Users.Ports.InBounds.Candidates;

public interface IUserCreationCandidate
{
    string FirstName { get; init; }
    string LastName { get; init; }
}