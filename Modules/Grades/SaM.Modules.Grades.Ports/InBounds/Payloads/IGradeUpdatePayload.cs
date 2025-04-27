namespace SaM.Modules.Grades.Ports.InBounds.Payloads;

public interface IGradeUpdatePayload
{
    decimal Notation { get; init; }
    int ExamId { get; init; }
    int StudentId { get; init; }
}