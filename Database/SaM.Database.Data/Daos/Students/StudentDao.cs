namespace SaM.Database.Data.Daos.Students;

public record StudentDao
{
    public int Id { get; set; }
    public required int UserId { get; set; }
}