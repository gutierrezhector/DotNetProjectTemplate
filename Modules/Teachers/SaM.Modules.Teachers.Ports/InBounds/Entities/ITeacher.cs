using SaM.Core.Types.Enums;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Teachers.Ports.InBounds.Entities;

public interface ITeacher
{
    int Id { get; set; }
    SchoolSubject SchoolSubject { get; set; }
    int UserId { get; set; }
    IUser? User { get; set; }
}