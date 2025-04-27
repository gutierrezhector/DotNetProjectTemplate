using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Web.Payloads;

public record UserCreationPayload : IUserCreationPayload
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}