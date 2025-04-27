namespace SaM.Modules.Grades.Ports.InBounds.Candidates;

public interface IGradeUpdateCandidate
{
    decimal Notation { get; init; }
    int ExamId { get; init; }
    int StudentId { get; init; }
}