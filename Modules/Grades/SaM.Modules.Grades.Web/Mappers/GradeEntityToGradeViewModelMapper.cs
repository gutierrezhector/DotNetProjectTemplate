using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.ViewModels.Grades;

namespace SaM.Modules.Grades.Web.Mappers;

public class GradeEntityToGradeViewModelMapper : Mapper<Grade, GradeViewModel>
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