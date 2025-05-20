using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Domain.Factories;
using SaM.Modules.Teachers.Domain.Validators;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Application.Applications;

public class TeachersApplication(
    ITeacherRepository teacherRepository,
    TeacherEntityFactory teacherEntityFactory,
    IValidator<ITeacherCreationCandidate> teacherCreationCandidateValidator,
    IValidator<TeacherUpdateWrapper> teacherUpdateCandidateValidator,
    Mapper<ITeacherCreationPayload, ITeacherCreationCandidate> teacherCreationCandidateMapper,
    Mapper<ITeacherUpdatePayload, ITeacherUpdateCandidate> teacherUpdateCandidateMapper
) : ITeachersApplication
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        return await teacherRepository.GetAllAsync();
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        return await teacherRepository.GetByIdAsync(id);
    }

    public async Task<Teacher> Create(ITeacherCreationPayload creationPayload)
    {
        var creationCandidate = teacherCreationCandidateMapper.MapNonNullable(creationPayload);
        var validationResult = await teacherCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var newTeacher = teacherEntityFactory.CreateFromCandidate(creationCandidate);
        await teacherRepository.Create(newTeacher);

        return newTeacher;
    }

    public async Task<Teacher> UpdateAsync(int id, ITeacherUpdatePayload updatePayload)
    {
        var updateCandidate = teacherUpdateCandidateMapper.MapNonNullable(updatePayload);
        var currentTeacher = await teacherRepository.GetByIdAsync(id);
        var validationResult = await teacherUpdateCandidateValidator.ValidateAsync(new TeacherUpdateWrapper(updateCandidate, currentTeacher));
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var newTeacher = await teacherRepository.UpdateAsync(id, updateCandidate);

        return newTeacher;
    }

    public async Task DeleteAsync(int id)
    {
        await teacherRepository.DeleteAsync(id);
    }
}