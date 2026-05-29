using SaM.Core.SharedKernel.ViewModels.Exams;
using SaM.Core.SharedKernel.ViewModels.Students;

namespace SaM.Core.SharedKernel.ViewModels.Grades;

public record GradeViewModel
{
    public int Id { get; set; }
    public decimal Notation { get; set; }
    public int ExamId { get; set; }
    public ExamViewModel? Exam { get; set; }
    public int StudentId { get; set; }
    public StudentViewModel? Student { get; set; }
}