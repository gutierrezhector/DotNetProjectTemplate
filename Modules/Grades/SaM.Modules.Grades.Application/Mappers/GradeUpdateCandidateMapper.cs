using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Application.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Application.Mappers;

public class GradeUpdateCandidateMapper : Mapper<IGradeUpdatePayload, IGradeUpdateCandidate>
{
    public override IGradeUpdateCandidate MapNonNullable(IGradeUpdatePayload from)
    {
        return new GradeUpdateCandidate
        {
            ExamId = from.ExamId,
            Notation = from.Notation,
            StudentId = from.StudentId,
        };
    }
}