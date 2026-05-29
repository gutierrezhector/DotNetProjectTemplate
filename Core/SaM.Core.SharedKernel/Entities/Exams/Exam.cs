using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.Entities.Teachers;

namespace SaM.Core.SharedKernel.Entities.Exams;

public class Exam
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public Teacher? ResponsibleTeacher { get; set; }
    public List<Grade>? Grades { get; set; }
}