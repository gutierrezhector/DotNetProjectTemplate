using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.ViewModels.Users;

namespace SaM.Modules.Users.Web.Factories;

public class UserViewModelFactory(
    Mapper<User, UserViewModel> userEntityViewModelMapper
) : ViewModelFactory<UserViewModel, User>
{

    public override UserViewModel CreateFromEntity(User entity)
    {
        var viewModel = userEntityViewModelMapper.MapNonNullable(entity);

        return viewModel;
    }
}