using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Application.Candidates;

public record ExamUpdateCandidate : IExamUpdateCandidate
{
    public required string Title { get; init; }
    public required DateTimeOffset StartDate { get; init; }
    public required DateTimeOffset EndDate { get; init; }
    public required decimal MaxPoints { get; init; }
    public required int ResponsibleTeacherId { get; init; }
}