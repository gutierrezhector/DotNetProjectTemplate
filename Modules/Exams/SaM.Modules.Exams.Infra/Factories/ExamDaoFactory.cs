using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Infra.Factories;

public class ExamDaoFactory(
    
    )
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

    public static void Update(ExamDao daoToUpdate, IExamUpdateCandidate updateCandidate)
    {
        daoToUpdate.Title = updateCandidate.Title;
        daoToUpdate.StartDate = updateCandidate.StartDate;
        daoToUpdate.EndDate = updateCandidate.EndDate;
        daoToUpdate.MaxPoints = updateCandidate.MaxPoints;
        daoToUpdate.ResponsibleTeacherId = updateCandidate.ResponsibleTeacherId;
    }
}