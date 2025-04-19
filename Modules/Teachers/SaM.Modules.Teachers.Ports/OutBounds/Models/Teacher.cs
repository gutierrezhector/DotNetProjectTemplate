using SaM.Core.Types.Enums;
using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Teachers.Ports.OutBounds.Models;

public class Teacher
{
    public int Id { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}