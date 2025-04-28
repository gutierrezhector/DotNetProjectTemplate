using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Domain.Factories;
using SaM.Modules.Grades.Domain.Mappers;
using SaM.Modules.Grades.Domain.Validators;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Grades.Ports.InBounds.Factories;

namespace SaM.Modules.Grades.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesDomain(this IServiceCollection services)
    {
        services.AddScoped<IGradeFactory, GradeFactory>();

        services.AddScoped<Mapper<GradeDao, IGrade>, GradeDaoToEntityMapper>();

        services.AddScoped<IValidator<IGradeCreationCandidate>, GradeCreationCandidateValidator>();
        services.AddScoped<IValidator<IGradeUpdateCandidate>, GradeUpdateCandidateValidator>();

        return services;
    }
}