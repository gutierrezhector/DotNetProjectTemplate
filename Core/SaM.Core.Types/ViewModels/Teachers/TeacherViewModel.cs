using SaM.Core.Types.Enums;
using SaM.Core.Types.ViewModels.Users;

namespace SaM.Core.Types.ViewModels.Teachers;

public record TeacherViewModel
{
    public int Id { get; init; }
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }
    public UserViewModel? User { get; set; }
}