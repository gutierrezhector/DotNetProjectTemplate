namespace SaM.Modules.Exams.Web.Candidates;

public record ExamCandidate
{
    public required string Title { get; init; }
    public required DateTimeOffset StartDate { get; init; } 
    public required DateTimeOffset EndDate { get; init; }
}