using SaM.Core.SharedKernel.Entities.Users;

namespace SaM.Core.SharedKernel.Entities.Students;

public class Student
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public User? User { get; set; }
}