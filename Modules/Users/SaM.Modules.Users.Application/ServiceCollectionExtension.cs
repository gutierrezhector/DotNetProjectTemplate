using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Users.Web.Abstractions;

namespace SaM.Modules.Users.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersApplication(this IServiceCollection services)
    {
        services.AddScoped<IUsersApplication, UsersApplication>();

        return services;
    }
}