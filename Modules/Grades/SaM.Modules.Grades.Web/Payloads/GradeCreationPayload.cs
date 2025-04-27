using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Web.Payloads;

public record GradeCreationPayload : IGradeCreationPayload
{
    public decimal Notation { get; init; }
    public int ExamId { get; init; }
    public int StudentId { get; init; }
}