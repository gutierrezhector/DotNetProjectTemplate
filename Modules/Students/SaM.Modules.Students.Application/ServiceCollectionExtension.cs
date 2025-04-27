using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Students.Application.Applications;
using SaM.Modules.Students.Application.Mappers;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Ports.InBounds.Applications;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsApplication(this IServiceCollection services)
    {
        services.AddScoped<IStudentsApplication, StudentsApplication>();

        services.AddScoped<Mapper<IStudentCreationPayload, IStudentCreationCandidate>, StudentCreationCandidateMapper>();
        services.AddScoped<Mapper<IStudentUpdatePayload, IStudentUpdateCandidate>, StudentUpdateCandidateMapper>();
        
        return services;
    }
}