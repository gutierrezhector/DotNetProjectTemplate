using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Grades.Infra.Repositories;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;

namespace SaM.Modules.Grades.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesInfra(this IServiceCollection services)
    {
        services.AddScoped<IGradesRepository, GradesRepository>();

        return services;
    }
}