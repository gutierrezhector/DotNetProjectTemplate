using SaM.Database.Data.Daos.Exams;

namespace SaM.Database.Data.Daos.Grades;

public record GradeDao
{
    public required int Id { get; set; }

    public required decimal Notation { get; init; }
    public required int ExamId { get; init; }
    public required ExamDao? Exam { get; init; }
}