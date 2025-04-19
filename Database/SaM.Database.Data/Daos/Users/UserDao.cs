namespace SaM.Database.Data.Daos.Users;

public record UserDao
{
    public int Id { get; set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}