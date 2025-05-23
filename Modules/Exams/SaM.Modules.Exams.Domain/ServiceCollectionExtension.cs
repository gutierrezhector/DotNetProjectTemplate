﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Domain.Factories;
using SaM.Modules.Exams.Domain.Mappers;
using SaM.Modules.Exams.Domain.Validators;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterExamsDomain(this IServiceCollection services)
    {
        services.AddScoped<IValidator<IExamCreationCandidate>, ExamCreationCandidateValidator>();
        services.AddScoped<IValidator<TeacherUpdateWrapper>, ExamUpdateCandidateValidator>();

        services.AddScoped<Mapper<ExamDao, Exam>, ExamDaoToExamEntityMapper>();

        services.AddScoped<ExamEntityFactory>();

        return services;
    }
}