using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Web.Payloads;

public record GradePayload
{
    public int ExamId { get; init; }
    public decimal Notation { get; init; }
    public GradeCandidate ToCandidate()
    {
        return new GradeCandidate
        {
            Notation = Notation,
            ExamId = ExamId,
        };
    }
}