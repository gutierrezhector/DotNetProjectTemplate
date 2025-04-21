using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Exams.Application.Validators;
using SaM.Modules.Exams.Web.Abstractions;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsApplication(this IServiceCollection services)
    {
        services.AddScoped<IExamsApplication, ExamsApplication>();
        services.AddScoped<IValidator<ExamCreationCandidate>, ExamCreationCandidateValidator>();
        services.AddScoped<IValidator<ExamUpdateCandidate>, ExamUpdateCandidateValidator>();
        
        return services;
    }
}