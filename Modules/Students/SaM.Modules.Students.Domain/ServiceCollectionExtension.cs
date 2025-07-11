using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Domain.Factories;
using SaM.Modules.Students.Domain.Mappers;
using SaM.Modules.Students.Domain.Validators;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsDomain(this IServiceCollection services)
    {
        services.AddScoped<StudentEntityFactory>();

        services.AddScoped<IValidator<IStudentCreationCandidate>, StudentCreationCandidateValidator>();
        services.AddScoped<IValidator<StudentUpdateWrapper>, StudentUpdateCandidateValidator>();

        services.AddScoped<Mapper<StudentDao, Student>, StudentDaoToStudentEntityMapper>();

        return services;
    }
}