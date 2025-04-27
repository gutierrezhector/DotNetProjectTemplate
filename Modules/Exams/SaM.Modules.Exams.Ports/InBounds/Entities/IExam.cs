using SaM.Modules.Teachers.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Ports.InBounds.Entities;

public interface IExam
{
    int Id { get; set; }
    string Title { get; set; }
    DateTimeOffset StartDate { get; set; }
    DateTimeOffset EndDate { get; set; }
    decimal MaxPoints { get; set; }
    int ResponsibleTeacherId { get; set; }
    ITeacher? ResponsibleTeacher { get; set; }
}