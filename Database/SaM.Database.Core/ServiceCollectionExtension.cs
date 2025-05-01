using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaM.Database.Core.Extensions;

namespace SaM.Database.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterEntityFramework(this IServiceCollection services)
    {
        services.AddDbContext<SaMDbContext>(options => options.SetupSqlServer());

        return services;
    }
}