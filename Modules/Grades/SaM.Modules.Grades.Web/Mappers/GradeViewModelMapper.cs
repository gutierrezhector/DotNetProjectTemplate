using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Web.ViewModels;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Web.Mappers;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Grades.Web.Mappers;

public class GradeViewModelMapper(
    Mapper<Student, StudentViewModel> studentViewModelMapper
) : Mapper<Grade, GradeViewModel>
{
    public override GradeViewModel Map(Grade from)
    {
        return new GradeViewModel
        {
            Id = from.Id,
            Notation = from.Notation,
            ExamId = from.ExamId,
            Exam = null,
            StudentId = from.StudentId,
            // TODO manage null
            Student = studentViewModelMapper.Map(from.Student)
        };
    }
}