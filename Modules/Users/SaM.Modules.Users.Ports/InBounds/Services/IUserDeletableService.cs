namespace SaM.Modules.Users.Ports.InBounds.Services;

public interface IUserDeletableService
{
    Task<bool> IsUserDeletableAsync(int  userId);
}