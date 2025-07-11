using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Core.Types.ViewModels.Students;

namespace SaM.Modules.Students.Web.Mappers;

public class StudentViewModelMapper : Mapper<Student, StudentViewModel>
{
    public override StudentViewModel MapNonNullable(Student from)
    {
        return new StudentViewModel
        {
            Id = from.Id,
            UserId = from.UserId,
        };
    }
}