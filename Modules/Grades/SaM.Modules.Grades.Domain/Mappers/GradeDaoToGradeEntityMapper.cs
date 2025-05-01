using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Grades;
using SaM.Database.Core.Daos.Grades;

namespace SaM.Modules.Grades.Domain.Mappers;

public class GradeDaoToGradeEntityMapper : Mapper<GradeDao, Grade>
{
    public override Grade MapNonNullable(GradeDao from)
    {
        return new Grade
        {
            Id = from.Id,
            Notation = from.Notation,
            StudentId = from.StudentId,
            ExamId = from.ExamId,
        };
    }
}