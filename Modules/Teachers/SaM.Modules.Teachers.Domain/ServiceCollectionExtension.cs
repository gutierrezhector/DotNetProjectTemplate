using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Factories;
using SaM.Modules.Teachers.Domain.Mappers;
using SaM.Modules.Teachers.Domain.Validators;
using SaM.Modules.Teachers.Ports.InBounds;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersDomain(this IServiceCollection services)
    {
        services.AddScoped<EntityFactory<Teacher, TeacherDao, ITeacherCreationCandidate>, TeacherEntityFactory>();

        services.AddScoped<Mapper<TeacherDao, Teacher>, TeacherDaoToTeacherEntityMapper>();
        services.AddScoped<Mapper<ITeacherCreationCandidate, Teacher>, TeacherCreationCandidateToTeacherEntityMapper>();

        services.AddScoped<IValidator<ITeacherCreationCandidate>, TeacherCreationCandidateValidator>();
        services.AddScoped<IValidator<TeacherUpdateWrapper>, TeacherUpdateCandidateValidator>();

        return services;
    }
}