using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Core.SharedKernel.ViewModels.Users;
using SaM.Modules.Users.Web.Factories;
using SaM.Modules.Users.Web.Mappers;

namespace SaM.Modules.Users.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersWeb(this IServiceCollection services)
    {
        services.AddScoped<UserViewModelFactory>();
        services.AddScoped<Mapper<User, UserViewModel>, UserEntityToUserViewModelMapper>();

        return services;
    }
}