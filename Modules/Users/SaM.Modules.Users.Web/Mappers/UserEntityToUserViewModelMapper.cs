using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Modules.Users.Web.Mappers;

public class UserEntityToUserViewModelMapper : Mapper<User, UserViewModel>
{
    public override UserViewModel MapNonNullable(User from)
    {
        return new UserViewModel
        {
            Id = from.Id,
            FirstName = from.FirstName,
            LastName = from.LastName,
        };
    }
}