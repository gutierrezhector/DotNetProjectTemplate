namespace SaM.Modules.Grades.Web.Candidates;

public record GradeCandidate
{
    public required int ExamId { get; init; }
    public required decimal Notation { get; init; }
}