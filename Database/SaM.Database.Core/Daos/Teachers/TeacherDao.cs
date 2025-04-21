using SaM.Core.Types.Enums;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Teachers.Domain.Entities;

namespace SaM.Database.Core.Daos.Teachers;

public class TeacherDao
{
    public int Id { get; init; }
    public int UserId { get; set; }
    public UserDao? User { get; set; }
    public required SchoolSubject SchoolSubject { get; set; }
    public List<ExamDao>? Exams { get; set; }

    public void UpdateFromDomainEntity(Teacher teacher)
    {
        UserId = teacher.UserId;
        SchoolSubject = teacher.SchoolSubject;
    }
}