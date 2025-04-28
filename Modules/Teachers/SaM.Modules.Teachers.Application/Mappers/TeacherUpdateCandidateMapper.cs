using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Application.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Application.Mappers;

public class TeacherUpdateCandidateMapper : Mapper<ITeacherUpdatePayload, ITeacherUpdateCandidate>
{
    public override ITeacherUpdateCandidate MapNonNullable(ITeacherUpdatePayload from)
    {
        return new TeacherUpdateCandidate
        {
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
        };
    }
}