using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Application.Mappers;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsApplication(this IServiceCollection services)
    {
        services.AddScoped<Mapper<IExamCreationPayload, IExamCreationCandidate>, ExamCreationPayloadToExamCreationCandidateMapper>();
        services.AddScoped<Mapper<IExamUpdatePayload, IExamUpdateCandidate>, ExamUpdatePayloadToExamUpdateCandidateMapper>();

        return services;
    }
}
