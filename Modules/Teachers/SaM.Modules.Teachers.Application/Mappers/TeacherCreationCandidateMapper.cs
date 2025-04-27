using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Application.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Application.Mappers;

public class TeacherCreationCandidateMapper : Mapper<ITeacherCreationPayload, ITeacherCreationCandidate>
{
    public override ITeacherCreationCandidate Map(ITeacherCreationPayload from)
    {
        return new TeacherCreationCandidate
        {
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
        };
    }
}