using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Web.Mappers;
using SaM.Modules.Exams.Web.ViewModels;

namespace SaM.Modules.Exams.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<Exam, ExamViewModel>, ExamViewModelMapper>();

        return services;
    }
}