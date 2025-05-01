using SaM.Core.Abstractions.Factories;
using SaM.Core.Types.Entities.Grades;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Infra.Factories;

public class GradeDaoFactory : DaoFactory<GradeDao, Grade, IGradeUpdateCandidate>
{
    public override GradeDao CreateFromEntity(Grade entity)
    {
        return new GradeDao
        {
            Notation = entity.Notation,
            ExamId = entity.ExamId,
            StudentId = entity.StudentId,
        };
    }

    public override void UpdateFromCandidate(GradeDao daoToUpdate, IGradeUpdateCandidate updateCandidate)
    {
        daoToUpdate.Notation = updateCandidate.Notation;
        daoToUpdate.ExamId = updateCandidate.ExamId;
        daoToUpdate.StudentId = updateCandidate.StudentId;
    }
}