using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Students.Infra.Factories;
using SaM.Modules.Students.Infra.Repositories;
using SaM.Modules.Students.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsInfra(this IServiceCollection services)
    {
        services.AddScoped<StudentDaoFactory>();
        services.AddScoped<IStudentsRepository, StudentsRepository>();

        return services;
    }
}