using SaM.Modules.Teachers.Ports.OutBounds.Models;

namespace SaM.Modules.Exams.Ports.OutBounds.Models;

public class Exam
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int MaxPoints { get; set; }
    public int MinPoints { get; set; }
    public int ResponsibleTeacherId { get; set; }
    public Teacher? ResponsibleTeacher { get; set; }
}