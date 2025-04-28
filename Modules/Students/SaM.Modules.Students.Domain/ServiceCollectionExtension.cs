using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Domain.Factories;
using SaM.Modules.Students.Domain.Mappers;
using SaM.Modules.Students.Domain.Validators;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Factories;

namespace SaM.Modules.Students.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterStudentsDomain(this IServiceCollection services)
    {
        services.AddScoped<IStudentEntityFactory, StudentEntityFactory>();

        services.AddScoped<IValidator<IStudentCreationCandidate>, StudentCreationCandidateValidator>();
        services.AddScoped<IValidator<IStudentUpdateCandidate>, StudentUpdateCandidateValidator>();

        services.AddScoped<Mapper<StudentDao, IStudent>, StudentDaoToEntityMapper>();

        return services;
    }
}