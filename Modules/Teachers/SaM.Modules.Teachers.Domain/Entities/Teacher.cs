using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Teachers.Domain.Entities;

public class Teacher : ITeacher
{
    public int Id { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
    public int UserId { get; set; }
    public IUser? User { get; set; }
}