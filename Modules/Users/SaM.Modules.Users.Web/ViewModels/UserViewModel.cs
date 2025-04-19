namespace SaM.Modules.Users.Web.ViewModels;

public record UserViewModel
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}