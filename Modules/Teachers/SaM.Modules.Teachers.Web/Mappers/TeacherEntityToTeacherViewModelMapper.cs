using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.ViewModels.Teachers;
using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Modules.Teachers.Web.Mappers;

public class TeacherEntityToTeacherViewModelMapper(
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