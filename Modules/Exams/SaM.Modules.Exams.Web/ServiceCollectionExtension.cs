using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Web.Mappers;
using SaM.Modules.Exams.Web.ViewModels;

namespace SaM.Modules.Exams.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<IExam, ExamViewModel>, ExamViewModelMapper>();

        return services;
    }
}