namespace SaM.Modules.Exams.Ports.InBounds.Candidates;

public interface IExamCreationCandidate
{
    string Title { get; init; }
    DateTimeOffset StartDate { get; init; } 
    DateTimeOffset EndDate { get; init; }
    decimal MaxPoints { get; init; }
    int ResponsibleTeacherId { get; init; }
}