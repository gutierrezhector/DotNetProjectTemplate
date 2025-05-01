using SaM.Core.Types.ViewModels.Grades;
using SaM.Core.Types.ViewModels.Teachers;

namespace SaM.Core.Types.ViewModels.Exams;

public record ExamViewModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public TeacherViewModel? ResponsibleTeacher { get; set; }
    public List<GradeViewModel>? Grades { get; set; }
}