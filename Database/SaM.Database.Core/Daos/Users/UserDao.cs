namespace SaM.Database.Core.Daos.Users;

public class UserDao
{
    public int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}