using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Domain.Entities;

public class Student : IStudent
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public IUser? User { get; set; }
}