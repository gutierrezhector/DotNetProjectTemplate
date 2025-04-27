using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Web.Payloads;

public record GradeUpdatePayload : IGradeUpdatePayload
{
    public decimal Notation { get; init; }
    public int ExamId { get; init; }
    public int StudentId { get; init; }
}