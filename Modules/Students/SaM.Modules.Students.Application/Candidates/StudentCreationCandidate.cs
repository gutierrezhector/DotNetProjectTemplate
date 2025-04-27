using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Application.Candidates;

public record StudentCreationCandidate : IStudentCreationCandidate
{
    public required int UserId { get; init; }
}