using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Teachers.Application.Factories;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Ports.InBounds;
using SaM.Modules.Teachers.Web.Abstractions;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application;

public class TeachersApplication(
    ITeacherRepository teacherRepository,
    IValidator<TeacherCreationCandidate> teacherCandidateValidator,
    IValidator<TeacherUpdateCandidate> teacherUpdateCandidateValidator
) : ITeacherApplication
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        return await teacherRepository.GetAllAsync();
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        return await teacherRepository.GetByIdAsync(id);
    }

    public async Task<Teacher> Create(TeacherCreationCandidate creationCandidate)
    {
        var validationResult = await teacherCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage);
            throw new BadRequestException(string.Join(", ", errors));
        }

        var newTeacher = TeacherFactory.Create(creationCandidate);
        await teacherRepository.Create(newTeacher);

        return newTeacher;
    }

    public async Task<Teacher> UpdateAsync(int id, TeacherUpdateCandidate updateCandidate)
    {
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