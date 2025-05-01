using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Infra.Factories;

public static class StudentDaoFactory
{
    public static StudentDao Create(Student student)
    {
        return new StudentDao
        {
            UserId = student.UserId,
        };
    }

    public static void Update(StudentDao dao, IStudentUpdateCandidate updateCandidate)
    {
        dao.UserId = updateCandidate.UserId;
    }
}