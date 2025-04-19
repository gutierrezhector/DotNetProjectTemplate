using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Web.Payloads;

public record UserPayload
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public UserCandidate ToCandidate()
    {
        return new UserCandidate
        {
            FirstName = FirstName,
            LastName = LastName
        };
    }
}