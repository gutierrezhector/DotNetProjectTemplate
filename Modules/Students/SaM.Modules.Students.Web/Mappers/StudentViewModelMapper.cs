using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Core.Types.Entities.Users;
using SaM.Modules.Students.Web.ViewModels;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Students.Web.Mappers;

public class StudentViewModelMapper(
    Mapper<User, UserViewModel> userViewModelMapper
) : Mapper<Student, StudentViewModel>
{
    public override StudentViewModel MapNonNullable(Student from)
    {
        return new StudentViewModel
        {
            Id = from.Id,
            UserId = from.Id,
            User = userViewModelMapper.MapNullable(from.User),
        };
    }
}