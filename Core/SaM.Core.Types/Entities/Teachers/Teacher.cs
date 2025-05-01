using SaM.Core.Types.Entities.Users;
using SaM.Core.Types.Enums;

namespace SaM.Core.Types.Entities.Teachers;

public class Teacher
{
    public int Id { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}