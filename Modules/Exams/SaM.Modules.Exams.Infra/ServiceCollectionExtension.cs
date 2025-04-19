using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Data.Daos.Exams;
using SaM.Modules.Exams.Infra.Mappers;
using SaM.Modules.Exams.Infra.Repositories;
using SaM.Modules.Exams.Ports.InBounds;
using SaM.Modules.Exams.Ports.OutBounds.Models;

namespace SaM.Modules.Exams.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsInfra(this IServiceCollection services)
    {
        services.AddScoped<IExamsRepository, ExamsRepository>();
        services.AddScoped<Mapper<ExamDao, Exam>, ExamsMapper>();

        return services;
    }
}