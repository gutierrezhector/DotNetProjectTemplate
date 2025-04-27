using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Grades.Web.Mappers;
using SaM.Modules.Grades.Web.ViewModels;

namespace SaM.Modules.Grades.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<IGrade, GradeViewModel>, GradeViewModelMapper>();
        
        return services;
    }
}