using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Domain.Factories;
using SaM.Modules.Grades.Domain.Mappers;
using SaM.Modules.Grades.Domain.Validators;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterGradesDomain(this IServiceCollection services)
    {
        services.AddScoped<EntityFromDaoFactory<Grade, GradeDao>, GradeEntityFromDaoFactory>();
        services.AddScoped<EntityFromCandidateFactory<Grade, IGradeCreationCandidate>, GradeEntityFromCandidateFactory>();

        services.AddScoped<Mapper<IGradeCreationCandidate, Grade>, GradeCreationCandidateToGradeEntityMapper>();
        services.AddScoped<Mapper<GradeDao, Grade>, GradeDaoToGradeEntityMapper>();

        services.AddScoped<IValidator<IGradeCreationCandidate>, GradeCreationCandidateValidator>();
        services.AddScoped<IValidator<GradeUpdateWrapper>, GradeUpdateCandidateValidator>();

        return services;
    }
}
