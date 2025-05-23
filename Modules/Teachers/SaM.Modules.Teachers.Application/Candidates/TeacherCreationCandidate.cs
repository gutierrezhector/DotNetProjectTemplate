using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Application.Candidates;

public record TeacherCreationCandidate : ITeacherCreationCandidate
{
    public required SchoolSubject SchoolSubject { get; init; }
    public required int UserId { get; init; }
}