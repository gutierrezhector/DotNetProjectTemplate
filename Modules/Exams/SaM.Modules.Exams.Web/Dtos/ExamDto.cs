namespace SaM.Modules.Exams.Web.Dtos;

public record ExamDto
{
    public string Title { get; init; }
    public DateTimeOffset StartDate { get; init; } 
    public DateTimeOffset EndDate { get; init; }
}