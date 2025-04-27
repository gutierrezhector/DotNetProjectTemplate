namespace SaM.Modules.Exams.Ports.InBounds.Payloads;

public interface IExamUpdatePayload
{
    string Title { get; init; }
    DateTimeOffset StartDate { get; init; } 
    DateTimeOffset EndDate { get; init; }
    decimal MaxPoints { get; init; }
    int ResponsibleTeacherId { get; set; }
}