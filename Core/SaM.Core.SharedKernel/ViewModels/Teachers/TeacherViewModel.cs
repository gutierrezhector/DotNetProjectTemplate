using SaM.Core.SharedKernel.Enums;
using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Core.SharedKernel.ViewModels.Teachers;

public record TeacherViewModel
{
    public int Id { get; init; }
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }
    public UserViewModel? User { get; set; }
}