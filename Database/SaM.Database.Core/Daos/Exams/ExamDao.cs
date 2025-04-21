using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Exams.Domain.Entities;

namespace SaM.Database.Core.Daos.Exams;
    
public class ExamDao
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset StartDate { get; set; } 
    public required DateTimeOffset EndDate { get; set; }
    public required decimal MaxPoints { get; set; }
    public required int ResponsibleTeacherId { get; set; }
    public TeacherDao? ResponsibleTeacher { get; set; }
    public List<GradeDao>? Grades { get; set; }

    public void UpdateFromDomainEntity(Exam exam)
    {
        Title = exam.Title;
        StartDate = exam.StartDate;
        EndDate = exam.EndDate;
        MaxPoints = exam.MaxPoints;
        ResponsibleTeacherId = exam.ResponsibleTeacherId;
    }
}
