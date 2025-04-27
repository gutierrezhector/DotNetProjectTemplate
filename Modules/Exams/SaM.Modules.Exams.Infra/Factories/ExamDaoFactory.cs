using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Infra.Factories;

public static class ExamDaoFactory
{
    public static ExamDao Create(IExam exam)
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