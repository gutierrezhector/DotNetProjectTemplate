using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Students.Web.Abstractions;

namespace SaM.Modules.Students.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsInfra(this IServiceCollection services)
    {
        services.AddScoped<IStudentsApplication, StudentsApplication>();

        return services;
    }
}