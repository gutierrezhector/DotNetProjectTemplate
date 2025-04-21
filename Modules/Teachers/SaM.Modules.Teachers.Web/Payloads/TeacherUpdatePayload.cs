using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Web.Payloads;

public record TeacherUpdatePayload
{
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }

    public TeacherUpdateCandidate ToCandidate()
    {
        return new TeacherUpdateCandidate
        {
            SchoolSubject = SchoolSubject,
            UserId = UserId
        };
    }
}