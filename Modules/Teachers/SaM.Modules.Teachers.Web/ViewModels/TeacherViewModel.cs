using SaM.Core.Types.Enums;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.ViewModels;

public record TeacherViewModel
{
    public int Id { get; init; }
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }
    public UserViewModel? User { get; init; }
}