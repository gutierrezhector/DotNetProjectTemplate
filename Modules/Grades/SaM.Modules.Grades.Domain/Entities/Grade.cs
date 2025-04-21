using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Students.Domain.Entities;

namespace SaM.Modules.Grades.Domain.Entities;

public class Grade
{
    public int Id { get; set; }
    public required decimal Notation { get; set; }
    public required int ExamId { get; set; }
    public Exam? Exam { get; set; }
    public required int StudentId { get; set; }
    public Student? Student { get; set; }
}