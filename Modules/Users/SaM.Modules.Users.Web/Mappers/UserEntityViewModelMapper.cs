using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Mappers;

public class UserEntityViewModelMapper : Mapper<IUser, UserViewModel>
{
    public override UserViewModel Map(IUser from)
    {
        return new UserViewModel
        {
            Id = from.Id,
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}