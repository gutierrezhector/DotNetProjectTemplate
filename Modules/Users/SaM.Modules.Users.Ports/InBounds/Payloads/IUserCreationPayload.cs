namespace SaM.Modules.Users.Ports.InBounds.Payloads;

public interface IUserCreationPayload
{
    string FirstName { get; init; }
    string LastName { get; init; }
}