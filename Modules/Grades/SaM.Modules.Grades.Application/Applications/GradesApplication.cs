using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Domain.Factories;
using SaM.Modules.Grades.Ports.InBounds.Applications;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Payloads;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;

namespace SaM.Modules.Grades.Application.Applications;

public class GradesApplication(
    IGradesRepository gradesRepository,
    GradeEntityFactory gradeEntityFactory,
    IValidator<IGradeCreationCandidate> gradeCreationCandidateValidator,
    IValidator<IGradeUpdateCandidate> gradeUpdateCandidateValidator,
    Mapper<IGradeCreationPayload, IGradeCreationCandidate> gradeCreationCandidateMapper,
    Mapper<IGradeUpdatePayload, IGradeUpdateCandidate> gradeUpdateCandidateMapper
) : IGradesApplication
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        return await gradesRepository.GetByIdAsync(id);
    }

    public async Task<Grade> CreateAsync(IGradeCreationPayload creationPayload)
    {
        var creationCandidate = gradeCreationCandidateMapper.MapNonNullable(creationPayload);
        var validationResult = await gradeCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var gradeToCreate = gradeEntityFactory.CreateFromCandidate(creationCandidate);
        var newGrade = await gradesRepository.CreateAsync(gradeToCreate);

        return newGrade;
    }

    public async Task<Grade> UpdateAsync(int id, IGradeUpdatePayload updatePayload)
    {
        var updateCandidate = gradeUpdateCandidateMapper.MapNonNullable(updatePayload);
        var validationResult = await gradeUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var newGrade = await gradesRepository.UpdateAsync(id, updateCandidate);

        return newGrade;
    }

    public async Task DeleteAsync(int id)
    {
        await gradesRepository.DeleteAsync(id);
    }
}