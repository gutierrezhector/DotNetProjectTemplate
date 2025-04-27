using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Teachers.Ports.InBounds.Applications;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Factories;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;
using SaM.Modules.Teachers.Ports.OuBounds;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Application.Applications;

public class TeachersApplication(
    ITeacherRepository teacherRepository,
    ITeacherEntityFactory teacherEntityFactory,
    IValidator<ITeacherCreationCandidate> teacherCandidateValidator,
    IValidator<ITeacherUpdateCandidate> teacherUpdateCandidateValidator,
    Mapper<ITeacherCreationPayload, ITeacherCreationCandidate> teacherCreationCandidateMapper,
    Mapper<ITeacherUpdatePayload, ITeacherUpdateCandidate> teacherUpdateCandidateMapper
) : ITeachersApplication
{
    public async Task<List<ITeacher>> GetAllAsync()
    {
        return await teacherRepository.GetAllAsync();
    }

    public async Task<ITeacher> GetByIdAsync(int id)
    {
        return await teacherRepository.GetByIdAsync(id);
    }

    public async Task<ITeacher> Create(ITeacherCreationPayload creationPayload)
    {
        var creationCandidate = teacherCreationCandidateMapper.Map(creationPayload);
        var validationResult = await teacherCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage);
            throw new BadRequestException(string.Join(", ", errors));
        }

        var newTeacher = teacherEntityFactory.Create(creationCandidate);
        await teacherRepository.Create(newTeacher);

        return newTeacher;
    }

    public async Task<ITeacher> UpdateAsync(int id, ITeacherUpdatePayload updatePayload)
    {
        var updateCandidate = teacherUpdateCandidateMapper.Map(updatePayload);
        var validationResult = await teacherUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var teacher = await teacherRepository.GetByIdAsync(id);
        
        teacher.SchoolSubject = updateCandidate.SchoolSubject;
        teacher.UserId = updateCandidate.UserId;
        
        var newTeacher = await teacherRepository.UpdateAsync(teacher);
        
        return newTeacher;
    }

    public async Task DeleteAsync(int id)
    {
        await teacherRepository.DeleteAsync(id);
    }
}