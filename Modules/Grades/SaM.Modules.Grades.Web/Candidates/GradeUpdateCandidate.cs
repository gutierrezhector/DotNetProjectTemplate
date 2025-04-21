namespace SaM.Modules.Grades.Web.Candidates;

public record GradeUpdateCandidate
{
    public required decimal Notation { get; init; }
    public required int ExamId { get; init; }
    public required int StudentId { get; init; }
}