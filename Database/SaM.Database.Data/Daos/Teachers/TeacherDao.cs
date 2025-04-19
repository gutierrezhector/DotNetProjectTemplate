using SaM.Core.Types.Enums;

namespace SaM.Database.Data.Daos.Teachers;

public record TeacherDao
{
    public int Id { get; set; }
    public int UserId { get; init; }
    public SchoolSubject SchoolSubject { get; init; }
}