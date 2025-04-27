using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Users.Infra.Repositories;
using SaM.Modules.Users.Ports.OutBounds;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Users.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersInfra(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }
}