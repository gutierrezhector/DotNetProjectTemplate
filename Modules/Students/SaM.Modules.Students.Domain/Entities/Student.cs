using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Students.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public User? User { get; set; }
}