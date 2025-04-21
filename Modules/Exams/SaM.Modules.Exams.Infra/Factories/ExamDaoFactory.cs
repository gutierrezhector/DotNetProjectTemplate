using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Infra.Factories;

public static class ExamDaoFactory
{
    public static ExamDao Create(Exam exam)
    {
        return new ExamDao
        {
            Title = exam.Title,
            StartDate = exam.StartDate,
            EndDate = exam.EndDate,
            MaxPoints = exam.MaxPoints,
            ResponsibleTeacherId = exam.ResponsibleTeacherId,
        };
    }
}