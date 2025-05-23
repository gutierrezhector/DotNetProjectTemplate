using SaM.Core.Types.Enums;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Users;

namespace SaM.Database.Core.Daos.Teachers;

public class TeacherDao
{
    public int Id { get; init; }
    public int UserId { get; set; }
    public UserDao? User { get; set; }
    public required SchoolSubject SchoolSubject { get; set; }
    public List<ExamDao>? Exams { get; set; }
}