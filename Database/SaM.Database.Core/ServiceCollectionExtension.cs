using Microsoft.Extensions.DependencyInjection;
using SaM.Database.Core.Extensions;

namespace SaM.Database.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterEntityFramework(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SaMDbContext>(options => options.SetupSqlServer(connectionString));

        return services;
    }
}