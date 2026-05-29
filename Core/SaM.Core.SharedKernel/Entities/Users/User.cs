namespace SaM.Core.SharedKernel.Entities.Users;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}