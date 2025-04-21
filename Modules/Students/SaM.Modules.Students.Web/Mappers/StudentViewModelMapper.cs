using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Web.ViewModels;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Students.Web.Mappers;

public class StudentViewModelMapper(
    Mapper<User, UserViewModel> userViewModelMapper
) : Mapper<Student, StudentViewModel>
{
    public override StudentViewModel Map(Student from)
    {
        return new StudentViewModel
        {
            Id = from.Id,
            UserId = from.Id,
            // TODO : manage null
            User = userViewModelMapper.Map(from.User)
        };
    }
}