using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SaM.Database.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterEntityFramework(this IServiceCollection services)
    {
        services.AddDbContext<SaMDbContext>(
            options => options
                .UseSqlServer(
                    "Server=DYOUGI;Database=SaM;Trusted_Connection=True;TrustServerCertificate=True;",
                    o => o.MigrationsAssembly("SaM.Database.Migrations"))
            );

        return services;
    }
}