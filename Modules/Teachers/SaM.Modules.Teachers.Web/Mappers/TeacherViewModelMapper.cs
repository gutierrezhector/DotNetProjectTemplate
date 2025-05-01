using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Entities.Users;
using SaM.Modules.Teachers.Web.ViewModels;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Mappers;

public class TeacherViewModelMapper(
    Mapper<User, UserViewModel> userViewModelMapper
) : Mapper<Teacher, TeacherViewModel>
{
    public override TeacherViewModel MapNonNullable(Teacher from)
    {
        return new TeacherViewModel
        {
            Id = from.Id,
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
            User = userViewModelMapper.MapNullable(from.User),
        };
    }
}