using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Web.Mappers;
using SaM.Modules.Students.Web.ViewModels;

namespace SaM.Modules.Students.Web;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsWeb(this IServiceCollection services)
    {
        services.AddScoped<Mapper<IStudent, StudentViewModel>, StudentViewModelMapper>();

        return services;
    }
}