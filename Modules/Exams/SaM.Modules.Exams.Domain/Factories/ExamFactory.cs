using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Factories;

namespace SaM.Modules.Exams.Domain.Factories;

public class ExamFactory : IExamFactory
{
    public Exam Create(IExamCreationCandidate candidate)
    {
        return new Exam
        {
            Title = candidate.Title,
            EndDate = candidate.EndDate,
            StartDate = candidate.StartDate,
            MaxPoints = candidate.MaxPoints,
            ResponsibleTeacherId = candidate.ResponsibleTeacherId,
        };
    }
}