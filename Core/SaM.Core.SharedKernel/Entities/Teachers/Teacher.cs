using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.Enums;

namespace SaM.Core.SharedKernel.Entities.Teachers;

public class Teacher
{
    public int Id { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}