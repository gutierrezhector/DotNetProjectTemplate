using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Teachers.Infra.Factories;
using SaM.Modules.Teachers.Infra.Repositories;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersInfra(this IServiceCollection services)
    {
        services.AddScoped<TeacherDaoFactory>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        return services;
    }
}