using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.ViewModels.Exams;
using SaM.Modules.Exams.Web.Factories;
using SaM.Modules.Exams.Web.Mappers;

namespace SaM.Modules.Exams.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsWeb(this IServiceCollection services)
    {
        services.AddScoped<ExamViewModelFactory>();
        services.AddScoped<Mapper<Exam, ExamViewModel>, ExamViewModelMapper>();

        return services;
    }
}