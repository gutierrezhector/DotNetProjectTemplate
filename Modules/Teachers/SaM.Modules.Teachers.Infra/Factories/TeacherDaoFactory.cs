using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Infra.Factories;

public static class TeacherDaoFactory
{
    public static TeacherDao Create(Teacher teacher)
    {
        return new TeacherDao
        {
            Id = teacher.Id,
            SchoolSubject = teacher.SchoolSubject,
            UserId = teacher.UserId,
        };
    }
    
    public static void Update(TeacherDao dao, ITeacherUpdateCandidate updateCandidate)
    {
        dao.UserId = updateCandidate.UserId;
        dao.SchoolSubject = updateCandidate.SchoolSubject;
    }
}