using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain.Mappers;

public class GradeCreationCandidateToGradeEntityMapper : Mapper<IGradeCreationCandidate, Grade>
{
    public override Grade MapNonNullable(IGradeCreationCandidate from)
    {
        return new Grade
        {
            Notation = from.Notation,
            ExamId = from.ExamId,
            StudentId = from.StudentId,
        };
    }
}