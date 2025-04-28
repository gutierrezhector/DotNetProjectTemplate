using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Application.Candidates;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Application.Mappers;

public class StudentCreationCandidateMapper : Mapper<IStudentCreationPayload, IStudentCreationCandidate>
{
    public override IStudentCreationCandidate MapNonNullable(IStudentCreationPayload from)
    {
        return new StudentCreationCandidate
        {
            UserId = from.UserId,
        };
    }
}