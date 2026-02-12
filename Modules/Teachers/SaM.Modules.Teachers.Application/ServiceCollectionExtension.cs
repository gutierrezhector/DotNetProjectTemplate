using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Teachers.Application.Applications;
using SaM.Modules.Teachers.Application.Mappers;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersApplication(this IServiceCollection services)
    {
        services.AddScoped<ITeachersApplication, TeachersApplication>();

        services.AddScoped<Mapper<ITeacherCreationPayload, ITeacherCreationCandidate>, TeacherCreationPayloadToTeacherCreationCandidateMapper>();
        services.AddScoped<Mapper<ITeacherUpdatePayload, ITeacherUpdateCandidate>, TeacherUpdatePayloadToTeacherUpdateCandidateMapper>();

        return services;
    }
}