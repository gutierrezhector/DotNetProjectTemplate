using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Exams.Web.Abstractions;

namespace SaM.Modules.Exams.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsApplication(this IServiceCollection services)
    {
        services.AddScoped<IExamsApplication, ExamsApplication>();
        
        return services;
    }
}