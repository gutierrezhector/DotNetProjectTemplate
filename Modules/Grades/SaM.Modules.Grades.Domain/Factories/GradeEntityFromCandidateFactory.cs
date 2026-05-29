using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain.Factories;

public class GradeEntityFromCandidateFactory(
    Mapper<IGradeCreationCandidate, Grade> gradeCreationCandidateToGradeEntityMapper
) : EntityFromCandidateFactory<Grade, IGradeCreationCandidate>
{
    public override Grade CreateFromCandidate(IGradeCreationCandidate creationCandidate)
    {
        return gradeCreationCandidateToGradeEntityMapper.MapNonNullable(creationCandidate);
    }
}
