using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Core.SharedKernel.ViewModels.Exams;

namespace SaM.Modules.Exams.Web.Mappers;

public class ExamEntityToExamViewModelMapper : Mapper<Exam, ExamViewModel>
{
    public override ExamViewModel MapNonNullable(Exam exam)
    {
        return new ExamViewModel
        {
            Id = exam.Id,
            Title = exam.Title,
            StartDate = exam.StartDate,
            EndDate = exam.EndDate,
            MaxPoints = exam.MaxPoints,
            ResponsibleTeacherId = exam.ResponsibleTeacherId,
        };
    }
}