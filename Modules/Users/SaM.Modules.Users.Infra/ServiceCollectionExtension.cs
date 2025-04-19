using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Data.Daos.Users;
using SaM.Modules.Users.Infra.Mappers;
using SaM.Modules.Users.Infra.Repositories;
using SaM.Modules.Users.Ports.InBounds;
using SaM.Modules.Users.Ports.OutBounds.Models;

namespace SaM.Modules.Users.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersInfra(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<Mapper<UserDao, User>, UserMapper>();

        return services;
    }
}