using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Database.Core.Daos.Grades;

public class GradeDao
{
    public int Id { get; init; }
    public required decimal Notation { get; set; }
    public required int ExamId { get; set; }
    public ExamDao? Exam { get; set; }
    public required int StudentId { get; set; }
    public StudentDao? Student { get; set; }

    public void UpdateFromCandidate(IGradeUpdateCandidate candidate)
    {
        Notation = candidate.Notation;
        ExamId = candidate.ExamId;
        StudentId = candidate.StudentId;
    }
}