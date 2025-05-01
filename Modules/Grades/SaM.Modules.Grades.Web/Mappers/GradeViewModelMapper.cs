using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.ViewModels.Grades;

namespace SaM.Modules.Grades.Web.Mappers;

public class GradeViewModelMapper : Mapper<Grade, GradeViewModel>
{
    public override GradeViewModel MapNonNullable(Grade from)
    {
        return new GradeViewModel
        {
            Id = from.Id,
            Notation = from.Notation,
            ExamId = from.ExamId,
            StudentId = from.StudentId,
        };
    }
}