using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Domain.Mappers;

public class StudentCreationCandidateToStudentEntityMapper : Mapper<IStudentCreationCandidate, Student>
{
    public override Student MapNonNullable(IStudentCreationCandidate from)
    {
        return new Student
        {
            UserId = from.UserId,
        };
    }
}