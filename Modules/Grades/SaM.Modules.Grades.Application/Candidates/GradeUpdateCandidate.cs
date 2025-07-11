using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Application.Candidates;

public record GradeUpdateCandidate : IGradeUpdateCandidate
{
    public required decimal Notation { get; init; }
    public required int ExamId { get; init; }
    public required int StudentId { get; init; }
}