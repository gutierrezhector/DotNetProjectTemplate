using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Core.SharedKernel.ViewModels.Teachers;
using SaM.Modules.Teachers.Web.Factories;
using SaM.Modules.Teachers.Web.Mappers;

namespace SaM.Modules.Teachers.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersWeb(this IServiceCollection services)
    {
        services.AddScoped<TeacherViewModelFactory>();
        services.AddScoped<Mapper<Teacher, TeacherViewModel>, TeacherEntityToTeacherViewModelMapper>();

        return services;
    }
}