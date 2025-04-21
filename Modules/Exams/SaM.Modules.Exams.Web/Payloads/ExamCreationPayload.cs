using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Web.Payloads;

public record ExamCreationPayload
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; } 
    public DateTimeOffset EndDate { get; init; }
    public decimal MaxPoints { get; init; }
    public int ResponsibleTeacherId { get; set; }
    public ExamCreationCandidate ToCandidate()
    {
        return new ExamCreationCandidate
        {
            Title = Title,
            StartDate = StartDate,
            EndDate = EndDate,
            MaxPoints = MaxPoints,
            ResponsibleTeacherId = ResponsibleTeacherId
        };
    }

}