using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Students.Ports.OutBounds.Models;

public class Student
{
    public int Id { get; set; }
    public required int UserId { get; init; }
    public User? User { get; set; }
}