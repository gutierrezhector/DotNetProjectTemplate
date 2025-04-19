using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Web.Payloads;

public record TeacherPayload
{
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }

    public TeacherCandidate ToCandidate()
    {
        return new TeacherCandidate
        {
            SchoolSubject = SchoolSubject,
            UserId = UserId
        };
    }
}