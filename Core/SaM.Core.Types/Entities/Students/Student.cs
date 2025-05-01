using SaM.Core.Types.Entities.Users;

namespace SaM.Core.Types.Entities.Students;

public class Student
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public User? User { get; set; }
}