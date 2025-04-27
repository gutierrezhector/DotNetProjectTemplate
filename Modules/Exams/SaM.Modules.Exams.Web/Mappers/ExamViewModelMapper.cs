using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Web.ViewModels;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Exams.Web.Mappers;

public class ExamViewModelMapper(
    Mapper<ITeacher, TeacherViewModel> teacherViewModelMapper
) : Mapper<IExam, ExamViewModel>
{
    public override ExamViewModel Map(IExam exam)
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