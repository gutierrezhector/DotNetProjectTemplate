using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Core.SharedKernel.ViewModels.Students;
using SaM.Modules.Students.Web.Factories;
using SaM.Modules.Students.Web.Mappers;

namespace SaM.Modules.Students.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsWeb(this IServiceCollection services)
    {
        services.AddScoped<StudentViewModelFactory>();
        services.AddScoped<Mapper<Student, StudentViewModel>, StudentEntityToStudentViewModelMapper>();

        return services;
    }
}