using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Grades.Domain.Entities;

public class Grade : IGrade
{
    public int Id { get; set; }
    public required decimal Notation { get; set; }
    public required int ExamId { get; set; }
    public IExam? Exam { get; set; }
    public required int StudentId { get; set; }
    public IStudent? Student { get; set; }
}