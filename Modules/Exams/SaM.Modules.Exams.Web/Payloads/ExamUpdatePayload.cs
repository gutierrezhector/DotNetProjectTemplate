using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Web.Payloads;

public record ExamUpdatePayload : IExamUpdatePayload
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; }
    public DateTimeOffset EndDate { get; init; }
    public decimal MaxPoints { get; init; }
    public int ResponsibleTeacherId { get; set; }
}