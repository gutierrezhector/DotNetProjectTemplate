using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Infra.Mappers;
using SaM.Modules.Grades.Infra.Repositories;
using SaM.Modules.Grades.Ports.InBounds;

namespace SaM.Modules.Grades.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesInfra(this IServiceCollection services)
    {
        services.AddScoped<IGradesRepository, GradesRepository>();
        services.AddScoped<Mapper<GradeDao, Grade>, GradeFromDaoMapper>();
        
        return services;
    }
}