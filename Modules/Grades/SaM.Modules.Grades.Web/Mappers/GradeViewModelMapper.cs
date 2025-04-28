using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Grades.Web.ViewModels;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Grades.Web.Mappers;

public class GradeViewModelMapper(
    Mapper<IStudent, StudentViewModel> studentViewModelMapper
) : Mapper<IGrade, GradeViewModel>
{
    public override GradeViewModel MapNonNullable(IGrade from)
    {
        return new GradeViewModel
        {
            Id = from.Id,
            Notation = from.Notation,
            ExamId = from.ExamId,
            Exam = null,
            StudentId = from.StudentId,
            Student = studentViewModelMapper.MapNullable(from.Student),
        };
    }
}