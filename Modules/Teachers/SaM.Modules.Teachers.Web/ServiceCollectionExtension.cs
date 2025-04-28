using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Web.Mappers;
using SaM.Modules.Teachers.Web.ViewModels;

namespace SaM.Modules.Teachers.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<ITeacher, TeacherViewModel>, TeacherViewModelMapper>();

        return services;
    }
}