using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Ports.InBounds.Entities;

public interface IStudent
{
    int Id { get; set; }
    int UserId { get; set; }
    IUser? User { get; set; }
}