using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Infra.Mappers;
using SaM.Modules.Students.Infra.Repositories;
using SaM.Modules.Students.Ports.InBounds;

namespace SaM.Modules.Students.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsInfra(this IServiceCollection services)
    {
        services.AddScoped<IStudentsRepository, StudentsRepository>();
        services.AddScoped<Mapper<StudentDao, Student>, StudentFromDaoMapper>();

        return services;
    }
}