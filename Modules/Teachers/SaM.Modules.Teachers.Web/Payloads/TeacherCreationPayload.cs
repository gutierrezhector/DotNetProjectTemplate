using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Web.Payloads;

public record TeacherCreationPayload
{
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }

    public TeacherCreationCandidate ToCandidate()
    {
        return new TeacherCreationCandidate
        {
            SchoolSubject = SchoolSubject,
            UserId = UserId
        };
    }
}