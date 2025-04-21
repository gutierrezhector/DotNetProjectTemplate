using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Teachers.Application.Validations;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersApplication(this IServiceCollection services)
    {
        services.AddScoped<IValidator<TeacherCreationCandidate>, TeacherCreationCandidateValidator>();
        services.AddScoped<IValidator<TeacherUpdateCandidate>, TeacherUpdateCandidateValidator>();

        return services;
    }
}