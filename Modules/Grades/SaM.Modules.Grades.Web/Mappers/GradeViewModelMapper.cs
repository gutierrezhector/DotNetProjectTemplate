using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Grades.Web.ViewModels;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Grades.Web.Mappers;

public class GradeViewModelMapper(
    Mapper<Student, StudentViewModel> studentViewModelMapper
) : Mapper<Grade, GradeViewModel>
{
    public override GradeViewModel MapNonNullable(Grade from)
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