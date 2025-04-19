using SaM.Database.Data.Daos.Teachers;

namespace SaM.Database.Data.Daos.Exams;
    
public record ExamDao
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required DateTimeOffset StartDate { get; init; } 
    public required DateTimeOffset EndDate { get; init; }
    public required int MaxPoints { get; init; }
    public required int MinPoints { get; init; }
    public required int ResponsibleTeacherId { get; init; }
    public TeacherDao? ResponsibleTeacher { get; init; }
}
