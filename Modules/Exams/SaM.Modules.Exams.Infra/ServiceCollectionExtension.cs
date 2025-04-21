using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Infra.Mappers;
using SaM.Modules.Exams.Infra.Repositories;
using SaM.Modules.Exams.Ports.InBounds;

namespace SaM.Modules.Exams.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsInfra(this IServiceCollection services)
    {
        services.AddScoped<IExamsRepository, ExamsRepository>();
        services.AddScoped<Mapper<ExamDao, Exam>, ExamFromDaoMapper>();

        return services;
    }
}