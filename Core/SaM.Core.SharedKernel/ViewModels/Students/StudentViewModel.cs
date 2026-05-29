using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Core.SharedKernel.ViewModels.Students;

public record StudentViewModel
{
    public int Id { get; set; }
    public int UserId { get; init; }
    public UserViewModel? User { get; set; }
}