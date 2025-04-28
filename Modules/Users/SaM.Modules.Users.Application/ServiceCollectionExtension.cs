using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Users.Application.Applications;
using SaM.Modules.Users.Application.Mappers;
using SaM.Modules.Users.Ports.InBounds.Applications;
using SaM.Modules.Users.Ports.InBounds.Candidates;
using SaM.Modules.Users.Ports.InBounds.Payloads;

namespace SaM.Modules.Users.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersApplication(this IServiceCollection services)
    {
        services.AddScoped<IUsersApplication, UsersApplication>();

        services.AddScoped<Mapper<IUserCreationPayload, IUserCreationCandidate>, UserCreationCandidateMapper>();
        services.AddScoped<Mapper<IUserUpdatePayload, IUserUpdateCandidate>, UserUpdateCandidateMapper>();

        return services;
    }
}