using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Domain.Factories;

public class StudentEntityFromCandidateFactory(
    Mapper<IStudentCreationCandidate, Student> studentCreationCandidateToStudentEntityMapper
) : EntityFromCandidateFactory<Student, IStudentCreationCandidate>
{
    public override Student CreateFromCandidate(IStudentCreationCandidate creationCandidate)
    {
        return studentCreationCandidateToStudentEntityMapper.MapNonNullable(creationCandidate);
    }
}
