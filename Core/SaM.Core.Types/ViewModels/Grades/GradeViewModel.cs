using SaM.Core.Types.ViewModels.Exams;
using SaM.Core.Types.ViewModels.Students;

namespace SaM.Core.Types.ViewModels.Grades;

public record GradeViewModel
{
    public int Id { get; set; }
    public decimal Notation { get; set; }
    public int ExamId { get; set; }
    public ExamViewModel? Exam { get; set; }
    public int StudentId { get; set; }
    public StudentViewModel? Student { get; set; }
}