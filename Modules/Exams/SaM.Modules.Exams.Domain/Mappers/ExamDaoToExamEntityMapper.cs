using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core.Daos.Exams;

namespace SaM.Modules.Exams.Domain.Mappers;

public class ExamDaoToExamEntityMapper : Mapper<ExamDao, Exam>
{
    public override Exam MapNonNullable(ExamDao from)
    {
        return new Exam
        {
            Id = from.Id,
            StartDate = from.StartDate,
            EndDate = from.EndDate,
            Title = from.Title,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
        };
    }
}