using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Grades.Application.Applications;
using SaM.Modules.Grades.Application.Mappers;
using SaM.Modules.Grades.Ports.InBounds.Applications;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesApplication(this IServiceCollection services)
    {
        services.AddScoped<IGradesApplication, GradesApplication>();

        services.AddScoped<Mapper<IGradeCreationPayload, IGradeCreationCandidate>, GradeCreationPayloadToGradeCreationCandidateMapper>();
        services.AddScoped<Mapper<IGradeUpdatePayload, IGradeUpdateCandidate>, GradeUpdatePayloadToGradeUpdateCandidateMapper>();

        return services;
    }
}