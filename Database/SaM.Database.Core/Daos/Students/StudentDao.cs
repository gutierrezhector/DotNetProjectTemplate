using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Users;

namespace SaM.Database.Core.Daos.Students;

public class StudentDao
{
    public int Id { get; init; }
    public required int UserId { get; set; }
    public UserDao? User { get; set; }
    public List<GradeDao>? Grades { get; set; }
}