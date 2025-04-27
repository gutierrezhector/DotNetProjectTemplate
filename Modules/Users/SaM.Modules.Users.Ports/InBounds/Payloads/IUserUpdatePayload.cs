namespace SaM.Modules.Users.Ports.InBounds.Payloads;

public interface IUserUpdatePayload
{
    string FirstName { get; init; }
    string LastName { get; init; }
}