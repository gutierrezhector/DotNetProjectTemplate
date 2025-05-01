using SaM.Core.Types.ViewModels.Users;

namespace SaM.Core.Types.ViewModels.Students;

public record StudentViewModel
{
    public int Id { get; set; }
    public int UserId { get; init; }
    public UserViewModel? User { get; set; }
}