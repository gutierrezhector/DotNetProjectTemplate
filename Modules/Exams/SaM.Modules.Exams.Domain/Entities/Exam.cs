using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Domain.Entities;

public class Exam : IExam
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public ITeacher? ResponsibleTeacher { get; set; }
}