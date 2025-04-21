using SaM.Modules.Exams.Web.ViewModels;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Grades.Web.ViewModels;

public record GradeViewModel
{
    public int Id { get; set; }
    public decimal Notation { get; set; }
    public int ExamId { get; set; }
    public ExamViewModel? Exam { get; set; }
    public int StudentId { get; set; }
    public StudentViewModel? Student { get; set; }
}