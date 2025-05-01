using SaM.Core.Abstractions.Factories;
using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Infra.Factories;

public class ExamDaoFactory : DaoFactory<ExamDao, Exam, IExamUpdateCandidate>
{
    public override ExamDao CreateFromEntity(Exam entity)
    {
        return new ExamDao
        {
            Title = entity.Title,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            MaxPoints = entity.MaxPoints,
            ResponsibleTeacherId = entity.ResponsibleTeacherId,
        };
    }

    public override void UpdateFromCandidate(ExamDao daoToUpdate, IExamUpdateCandidate updateCandidate)
    {
        daoToUpdate.Title = updateCandidate.Title;
        daoToUpdate.StartDate = updateCandidate.StartDate;
        daoToUpdate.EndDate = updateCandidate.EndDate;
        daoToUpdate.MaxPoints = updateCandidate.MaxPoints;
        daoToUpdate.ResponsibleTeacherId = updateCandidate.ResponsibleTeacherId;
    }
}