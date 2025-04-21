using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Infra.Mappers;
using SaM.Modules.Teachers.Infra.Repositories;
using SaM.Modules.Teachers.Ports.InBounds;

namespace SaM.Modules.Teachers.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersInfra(this IServiceCollection services)
    {
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<Mapper<TeacherDao, Teacher>, TeacherFromDaoMapper>();

        return services;
    }
}