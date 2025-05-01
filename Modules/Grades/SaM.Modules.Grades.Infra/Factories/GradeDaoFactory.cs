using SaM.Core.Types.Entities.Grades;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Infra.Factories;

public static class GradeDaoFactory
{
    public static GradeDao Create(Grade grade)
    {
        return new GradeDao
        {
            Notation = grade.Notation,
            ExamId = grade.ExamId,
            StudentId = grade.StudentId,
        };
    }
    
    public static void Update(GradeDao dao, IGradeUpdateCandidate updateCandidate)
    {
        dao.Notation = updateCandidate.Notation;
        dao.ExamId = updateCandidate.ExamId;
        dao.StudentId = updateCandidate.StudentId;
    }
}