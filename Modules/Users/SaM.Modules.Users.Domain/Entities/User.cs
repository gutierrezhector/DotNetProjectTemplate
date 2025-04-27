using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Users.Domain.Entities;

public class User : IUser
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}