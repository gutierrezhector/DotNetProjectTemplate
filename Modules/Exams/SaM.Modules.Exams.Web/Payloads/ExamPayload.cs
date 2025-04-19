using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Web.Payloads;

public record ExamPayload
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; } 
    public DateTimeOffset EndDate { get; init; }

    public ExamCandidate ToCandidate()
    {
        return new ExamCandidate
        {
            Title = Title,
            StartDate = StartDate,
            EndDate = EndDate,
        };
    }
}