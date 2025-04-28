using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Web.ViewModels;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Students.Web.Mappers;

public class StudentViewModelMapper(
    Mapper<IUser, UserViewModel> userViewModelMapper
) : Mapper<IStudent, StudentViewModel>
{
    public override StudentViewModel Map(IStudent from)
    {
        return new StudentViewModel
        {
            Id = from.Id,
            UserId = from.Id,
            // TODO : manage null
            User = userViewModelMapper.Map(from.User),
        };
    }
}