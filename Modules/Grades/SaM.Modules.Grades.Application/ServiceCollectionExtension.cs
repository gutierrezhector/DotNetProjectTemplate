using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Grades.Application.Validators;
using SaM.Modules.Grades.Web.Abstractions;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesApplication(this IServiceCollection services)
    {
        services.AddScoped<IValidator<GradeCreationCandidate>, GradeCreationCandidateValidator>();
        services.AddScoped<IValidator<GradeUpdateCandidate>, GradeUpdateCandidateValidator>();
        services.AddScoped<IGradesApplication, GradesApplication>();
        
        return services;
    }
}