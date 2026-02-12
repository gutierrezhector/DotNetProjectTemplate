using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Application.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Application.Mappers;

public class GradeCreationPayloadToGradeCreationCandidateMapper : Mapper<IGradeCreationPayload, IGradeCreationCandidate>
{
    public override IGradeCreationCandidate MapNonNullable(IGradeCreationPayload from)
    {
        return new GradeCreationCandidate
        {
            ExamId = from.ExamId,
            Notation = from.Notation,
            StudentId = from.StudentId,
        };
    }
}