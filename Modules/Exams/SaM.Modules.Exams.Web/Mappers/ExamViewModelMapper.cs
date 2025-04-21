using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Web.ViewModels;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Exams.Web.Mappers;

public class ExamViewModelMapper(
    Mapper<Teacher, TeacherViewModel> teacherViewModelMapper
) : Mapper<Exam, ExamViewModel>
{
    public override ExamViewModel Map(Exam exam)
    {
        return new ExamViewModel
        {
            Id = exam.Id,
            Title = exam.Title,
            StartDate = exam.StartDate,
            EndDate = exam.EndDate,
            MaxPoints = exam.MaxPoints,
            ResponsibleTeacherId = exam.ResponsibleTeacherId,
            // TODO : manage null
            ResponsibleTeacher = teacherViewModelMapper.Map(exam.ResponsibleTeacher)
        };
    }
}