using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Web.Mappers;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Students.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<Student, StudentViewModel>, StudentViewModelMapper>();

        return services;
    }
}