using SaM.Core.Types.Enums;

namespace SaM.Modules.Teachers.Ports.InBounds.Candidates;

public interface ITeacherCreationCandidate
{
    SchoolSubject SchoolSubject { get; init; }
    int UserId { get; init; }
}