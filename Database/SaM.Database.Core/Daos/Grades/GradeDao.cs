using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Students;

namespace SaM.Database.Core.Daos.Grades;

public class GradeDao
{
    public int Id { get; init; }
    public required decimal Notation { get; set; }
    public required int ExamId { get; set; }
    public ExamDao? Exam { get; set; }
    public required int StudentId { get; set; }
    public StudentDao? Student { get; set; }
}