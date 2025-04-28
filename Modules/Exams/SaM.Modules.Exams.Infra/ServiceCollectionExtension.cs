using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Exams.Infra.Repositories;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsInfra(this IServiceCollection services)
    {
        services.AddScoped<IExamsRepository, ExamsRepository>();

        return services;
    }
}