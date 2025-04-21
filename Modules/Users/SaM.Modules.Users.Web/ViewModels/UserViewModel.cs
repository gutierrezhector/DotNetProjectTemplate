namespace SaM.Modules.Users.Web.ViewModels;

public record UserViewModel
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}