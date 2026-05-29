using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Domain.Factories;

public class TeacherEntityFromCandidateFactory(
    Mapper<ITeacherCreationCandidate, Teacher> teacherCreationCandidateToTeacherEntityMapper
) : EntityFromCandidateFactory<Teacher, ITeacherCreationCandidate>
{
    public override Teacher CreateFromCandidate(ITeacherCreationCandidate creationCandidate)
    {
        return teacherCreationCandidateToTeacherEntityMapper.MapNonNullable(creationCandidate);
    }
}
