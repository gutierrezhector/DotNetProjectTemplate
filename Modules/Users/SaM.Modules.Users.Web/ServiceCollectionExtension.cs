using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Ports.InBounds.Entities;
using SaM.Modules.Users.Web.Mappers;
using SaM.Modules.Users.Web.ViewModels;

namespace SaM.Modules.Users.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<IUser, UserViewModel>, UserEntityViewModelMapper>();

        return services;
    }
}