using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Application.Candidates;

public record StudentUpdateCandidate : IStudentUpdateCandidate
{
    public required int UserId { get; init; }
}