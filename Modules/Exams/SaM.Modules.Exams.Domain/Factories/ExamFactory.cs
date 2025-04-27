using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Ports.InBounds.Factories;

namespace SaM.Modules.Exams.Domain.Factories;

public class ExamFactory : IExamFactory
{
    public IExam Create(IExamCreationCandidate candidate)
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