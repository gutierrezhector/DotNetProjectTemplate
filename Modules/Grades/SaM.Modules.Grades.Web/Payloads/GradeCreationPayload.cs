using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Web.Payloads;

public record GradeCreationPayload
{
    public decimal Notation { get; init; }
    public int ExamId { get; init; }
    public int StudentId { get; init; }
    public GradeCreationCandidate ToCandidate()
    {
        return new GradeCreationCandidate
        {
            Notation = Notation,
            ExamId = ExamId,
            StudentId = StudentId,
        };
    }
}