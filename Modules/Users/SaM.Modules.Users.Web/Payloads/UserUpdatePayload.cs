using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Web.Payloads;

public record UserUpdatePayload
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public UserUpdateCandidate ToCandidate()
    {
        return new UserUpdateCandidate
        {
            FirstName = FirstName,
            LastName = LastName
        };
    }
}