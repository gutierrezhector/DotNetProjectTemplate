using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Grades.Ports.InBounds.Entities;

public interface IGrade
{
    int Id { get; set; }
    decimal Notation { get; set; }
    int ExamId { get; set; }
    IExam? Exam { get; set; }
    int StudentId { get; set; }
    IStudent? Student { get; set; }
}