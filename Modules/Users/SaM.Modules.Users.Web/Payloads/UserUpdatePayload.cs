using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Web.Payloads;

public record UserUpdatePayload : IUserUpdatePayload
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}