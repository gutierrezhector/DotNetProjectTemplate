using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Domain.Factories;
using SaM.Modules.Exams.Domain.Validators;
using SaM.Modules.Exams.Ports.InBounds.Applications;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Payloads;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Application.Applications;

public class ExamsApplication(
    IExamsRepository examRepository,
    ExamEntityFactory examEntityFactory,
    IValidator<IExamCreationCandidate> examCreationCandidateValidator,
    IValidator<TeacherUpdateWrapper> examUpdateCandidateValidator,
    Mapper<IExamCreationPayload, IExamCreationCandidate> examCreationPayloadMapper,
    Mapper<IExamUpdatePayload, IExamUpdateCandidate> examUpdatePayloadMapper
) : IExamsApplication
{
    public async Task<List<Exam>> GetAllAsync()
    {
        return await examRepository.GetAllAsync();
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        return await examRepository.GetByIdAsync(id);
    }

    public async Task<Exam> CreateAsync(IExamCreationPayload creationPayload)
    {
        var creationCandidate = examCreationPayloadMapper.MapNonNullable(creationPayload);
        var validationResult = await examCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var examToCreate = examEntityFactory.CreateFromCandidate(creationCandidate);

        return await examRepository.CreateAsync(examToCreate);
    }

    public async Task<Exam> UpdateAsync(int id, IExamUpdatePayload updatePayload)
    {
        var updateCandidate = examUpdatePayloadMapper.MapNonNullable(updatePayload);
        var currentExam = await examRepository.GetByIdAsync(id);
        var validationResult = await examUpdateCandidateValidator.ValidateAsync(new TeacherUpdateWrapper(updateCandidate, currentExam));
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        return await examRepository.UpdateAsync(id, updateCandidate);
    }

    public async Task DeleteAsync(int id)
    {
        await examRepository.DeleteAsync(id);
    }
}