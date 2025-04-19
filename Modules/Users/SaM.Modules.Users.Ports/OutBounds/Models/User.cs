namespace SaM.Modules.Users.Ports.OutBounds.Models;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}