using SaM.Modules.Teachers.Domain.Entities;

namespace SaM.Modules.Exams.Domain.Entities;

public class Exam
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public Teacher? ResponsibleTeacher { get; set; }
}