using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Dtos;
using SaM.Modules.Exams.Web.Mappers;

namespace SaM.Modules.Exams.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<Exam, ExamDto>, ExamMapper>();

        return services;
    }
}