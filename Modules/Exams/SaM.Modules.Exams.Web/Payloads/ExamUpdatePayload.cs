using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Web.Payloads;

public record ExamUpdatePayload
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; } 
    public DateTimeOffset EndDate { get; init; }
    public decimal MaxPoints { get; init; }
    public int ResponsibleTeacherId { get; set; }
    public ExamUpdateCandidate ToCandidate()
    {
        return new ExamUpdateCandidate
        {
            Title = Title,
            StartDate = StartDate,
            EndDate = EndDate,
            MaxPoints = MaxPoints,
            ResponsibleTeacherId = ResponsibleTeacherId
        };
    }

}