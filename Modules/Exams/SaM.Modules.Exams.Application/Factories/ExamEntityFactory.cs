using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Application.Factories;

public static class ExamEntityFactory
{
    public static Exam Create(ExamCreationCandidate candidate)
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