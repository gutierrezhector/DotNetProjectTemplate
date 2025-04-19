using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Ports.OutBounds.Models;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Mappers;

public class UserMapper : Mapper<User, UserViewModel>
{
    public override UserViewModel Map(User from)
    {
        return new UserViewModel
        {
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}