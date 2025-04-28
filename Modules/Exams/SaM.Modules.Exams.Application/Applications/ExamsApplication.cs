using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Exams.Ports.InBounds.Applications;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Ports.InBounds.Factories;
using SaM.Modules.Exams.Ports.InBounds.Payloads;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.Applications;

public class ExamsApplication(
    IExamsRepository repository,
    IExamFactory examFactory,
    IValidator<IExamCreationCandidate> examCreationCandidateValidator,
    IValidator<IExamUpdateCandidate> examUpdateCandidateValidator,
    Mapper<IExamCreationPayload, IExamCreationCandidate> examCreationPayloadMapper,
    Mapper<IExamUpdatePayload, IExamUpdateCandidate> examUpdatePayloadMapper
) : IExamsApplication
{
    public async Task<List<IExam>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<IExam> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<IExam> CreateAsync(IExamCreationPayload creationPayload)
    {
        var creationCandidate = examCreationPayloadMapper.MapNonNullable(creationPayload);
        var validationResult = await examCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var examToCreate = examFactory.Create(creationCandidate);

        return await repository.CreateAsync(examToCreate);
    }

    public async Task<IExam> UpdateAsync(int id, IExamUpdatePayload updatePayload)
    {
        var updateCandidate = examUpdatePayloadMapper.MapNonNullable(updatePayload);
        var validationResult = await examUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        return await repository.UpdateAsync(id, updateCandidate);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}