using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Users.Domain.Factories;
using SaM.Modules.Users.Domain.Mappers;
using SaM.Modules.Users.Domain.Validators;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterUsersDomain(this IServiceCollection services)
    {
        services.AddScoped<UserEntityFactory>();

        services.AddScoped<Mapper<UserDao, User>, UserDaoToUserEntityMapper>();

        services.AddScoped<IValidator<IUserCreationCandidate>, UserCreationCandidateValidator>();
        services.AddScoped<IValidator<IUserUpdateCandidate>, UserUpdateCandidateValidator>();

        return services;
    }
}