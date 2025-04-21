using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Web.Payloads;

public record GradeUpdatePayload
{
    public decimal Notation { get; init; }
    public int ExamId { get; init; }
    public int StudentId { get; init; }
    public GradeUpdateCandidate ToCandidate()
    {
        return new GradeUpdateCandidate
        {
            Notation = Notation,
            ExamId = ExamId,
            StudentId = StudentId,
        };
    }
}