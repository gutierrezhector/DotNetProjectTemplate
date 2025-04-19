using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Application.Factories;

public static class ExamFactory
{
    public static Exam Create(ExamCandidate candidate)
    {
        return new Exam
        {
            Title = candidate.Title,
            EndDate = candidate.EndDate,
            StartDate = candidate.StartDate
        };
    }
}