using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Web.Payloads;

public record UserCreationPayload
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public UserCreationCandidate ToCandidate()
    {
        return new UserCreationCandidate
        {
            FirstName = FirstName,
            LastName = LastName
        };
    }
}