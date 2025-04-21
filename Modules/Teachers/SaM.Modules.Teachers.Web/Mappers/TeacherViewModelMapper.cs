using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Web.ViewModels;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Teachers.Web.Mappers;

public class TeacherViewModelMapper(
    Mapper<User, UserViewModel> userViewModelMapper
    ) : Mapper<Teacher, TeacherViewModel>
{
    public override TeacherViewModel Map(Teacher from)
    {
        return new TeacherViewModel
        {
            Id = from.Id,
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
            // TODO : manage null
            User = userViewModelMapper.Map(from.User),
        };
    }
}