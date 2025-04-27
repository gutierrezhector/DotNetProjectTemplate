using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Application.Candidates;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Application.Mappers;

public class StudentUpdateCandidateMapper : Mapper<IStudentUpdatePayload, IStudentUpdateCandidate>
{
    public override IStudentUpdateCandidate Map(IStudentUpdatePayload from)
    {
        return new StudentUpdateCandidate
        {
            UserId = from.UserId,
        };
    }
}