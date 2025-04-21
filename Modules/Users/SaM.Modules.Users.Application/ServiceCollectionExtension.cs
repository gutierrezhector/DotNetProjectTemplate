using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Modules.Users.Application.Validators;
using SaM.Modules.Users.Web.Abstractions;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersApplication(this IServiceCollection services)
    {
        services.AddScoped<IUsersApplication, UsersApplication>();
        
        services.AddScoped<IValidator<UserCreationCandidate>, UserCreationCandidateValidator>();
        services.AddScoped<IValidator<UserUpdateCandidate>, UserUpdateCandidateValidator>();

        return services;
    }
}