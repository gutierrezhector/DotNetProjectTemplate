using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Exams.Web.ViewModels;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Exams.Web.Mappers;

public class ExamViewModelMapper(
    Mapper<Teacher, TeacherViewModel> teacherViewModelMapper
) : Mapper<Exam, ExamViewModel>
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
            ResponsibleTeacher = teacherViewModelMapper.MapNullable(exam.ResponsibleTeacher),
        };
    }
}