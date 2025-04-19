namespace SaM.Modules.Grades.Ports.OutBounds.Models;

public class Grade
{
    public int Id { get; set; }
    public required decimal Notation { get; init; }
    public required int ExamId { get; init; }
}