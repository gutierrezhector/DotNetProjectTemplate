namespace SaM.Modules.Exams.Web.Candidates;

public record ExamUpdateCandidate
{
    public required string Title { get; init; }
    public required DateTimeOffset StartDate { get; init; } 
    public required DateTimeOffset EndDate { get; init; }
    public required decimal MaxPoints { get; init; }
    public required int ResponsibleTeacherId { get; init; }
}