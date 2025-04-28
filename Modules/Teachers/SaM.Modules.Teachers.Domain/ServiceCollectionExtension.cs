using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Factories;
using SaM.Modules.Teachers.Domain.Mappers;
using SaM.Modules.Teachers.Domain.Validators;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Factories;

namespace SaM.Modules.Teachers.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterTeachersDomain(this IServiceCollection services)
    {
        services.AddScoped<ITeacherEntityFactory, TeacherEntityFactory>();

        services.AddScoped<Mapper<TeacherDao, ITeacher>, TeacherDaoToEntityMapper>();

        services.AddScoped<IValidator<ITeacherCreationCandidate>, TeacherCreationCandidateValidator>();
        services.AddScoped<IValidator<ITeacherUpdateCandidate>, TeacherUpdateCandidateValidator>();

        return services;
    }
}