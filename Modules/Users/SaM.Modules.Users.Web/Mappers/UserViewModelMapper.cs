using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Domain.Entities;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web.Mappers;

public class UserViewModelMapper : Mapper<User, UserViewModel>
{
    public override UserViewModel Map(User from)
    {
        return new UserViewModel
        {
            Id = from.Id,
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}