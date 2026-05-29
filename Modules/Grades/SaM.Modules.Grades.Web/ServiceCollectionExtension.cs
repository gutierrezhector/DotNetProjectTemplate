using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.ViewModels.Grades;
using SaM.Modules.Grades.Web.Factories;
using SaM.Modules.Grades.Web.Mappers;

namespace SaM.Modules.Grades.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesWeb(this IServiceCollection services)
    {
        services.AddScoped<GradeViewModelFactory>();
        services.AddScoped<Mapper<Grade, GradeViewModel>, GradeEntityToGradeViewModelMapper>();

        return services;
    }
}