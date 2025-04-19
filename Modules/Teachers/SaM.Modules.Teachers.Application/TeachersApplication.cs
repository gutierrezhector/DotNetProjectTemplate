using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Teachers.Application.Factories;
using SaM.Modules.Teachers.Ports.InBounds;
using SaM.Modules.Teachers.Ports.OutBounds.Models;
using SaM.Modules.Teachers.Web.Abstractions;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application;

public class TeachersApplication(
    ITeacherRepository teacherRepository,
    IValidator<TeacherCandidate> teacherCandidateValidator)
    : ITeacherApplication
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        var teachers = await teacherRepository.GetAllAsync();

        return teachers;
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        var teacher = await teacherRepository.GetByIdAsync(id);

        return teacher;
    }

    public async Task<Teacher> Create(TeacherCandidate candidate)
    {
        var validationResult = await teacherCandidateValidator.ValidateAsync(candidate);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage);
            throw new BadRequestException(string.Join(", ", errors));
        }

        var newTeacher = TeacherFactory.Create(candidate);
        await teacherRepository.Create(newTeacher);

        return newTeacher;
    }
}