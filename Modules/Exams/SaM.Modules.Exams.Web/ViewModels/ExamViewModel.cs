using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Exams.Web.ViewModels;

public record ExamViewModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public TeacherViewModel? ResponsibleTeacher { get; set; }
}