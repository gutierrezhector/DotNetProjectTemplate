using SaM.Core.Types.Enums;

namespace SaM.Modules.Teachers.Web.Candidates;

public record TeacherUpdateCandidate
{
    public required SchoolSubject SchoolSubject { get; init; }
    public required int UserId { get; init; }
}