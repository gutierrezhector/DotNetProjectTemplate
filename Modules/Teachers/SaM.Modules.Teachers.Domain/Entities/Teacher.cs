using SaM.Core.Types.Enums;
using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Teachers.Domain.Entities;

public class Teacher
{
    public int Id { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}