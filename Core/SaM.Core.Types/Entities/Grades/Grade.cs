using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Students;

namespace SaM.Core.Types.Entities.Grades;

public class Grade
{
    public int Id { get; set; }
    public required decimal Notation { get; set; }
    public required int ExamId { get; set; }
    public Exam? Exam { get; set; }
    public required int StudentId { get; set; }
    public Student? Student { get; set; }
}