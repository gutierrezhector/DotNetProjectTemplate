using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Domain.Mappers;

public class TeacherCreationCandidateToTeacherEntityMapper : Mapper<ITeacherCreationCandidate, Teacher>
{
    public override Teacher MapNonNullable(ITeacherCreationCandidate from)
    {
        return new Teacher
        {
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
        };
    }
}