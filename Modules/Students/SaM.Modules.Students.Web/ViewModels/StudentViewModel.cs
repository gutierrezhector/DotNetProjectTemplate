using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Students.Web.ViewModels;

public record StudentViewModel
{
    public int Id { get; set; }
    public int UserId { get; init; }
    public UserViewModel? User { get; set; }
}