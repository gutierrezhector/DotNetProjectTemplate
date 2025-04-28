using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Web.ViewModels;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Mappers;

public class TeacherViewModelMapper(
    Mapper<IUser, UserViewModel> userViewModelMapper
) : Mapper<ITeacher, TeacherViewModel>
{
    public override TeacherViewModel MapNonNullable(ITeacher from)
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