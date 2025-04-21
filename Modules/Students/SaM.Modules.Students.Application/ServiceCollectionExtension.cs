using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Students.Application.Validations;
using SaM.Modules.Students.Web.Abstractions;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentsApplication, StudentsApplication>();
        services.AddScoped<IValidator<StudentCreationCandidate>, StudentCreationCandidateValidator>();
        services.AddScoped<IValidator<StudentUpdateCandidate>, StudentUpdateCandidateValidator>();

        return services;
    }
}