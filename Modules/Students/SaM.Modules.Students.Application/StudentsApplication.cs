using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Students.Application.Factories;
using SaM.Modules.Students.Application.Validations;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Web.Abstractions;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Application;

public class StudentsApplication(
    IStudentsRepository studentsRepository,
    IValidator<StudentCreationCandidate> studentCreationCandidateValidator,
    IValidator<StudentUpdateCandidate> studentUpdateCandidateValidator
) : IStudentsApplication
{
    public async Task<List<Student>> GetAllAsync()
    {
        return await studentsRepository.GetAllAsync();
    }

    public async Task<Student> GetByIdAsync(int studentId)
    {
        return await studentsRepository.GetByIdAsync(studentId);
    }

    public async Task<Student> CreateAsync(StudentCreationCandidate creationCandidate)
    {
        var validationResult = await studentCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var studentToCreate = StudentFactory.Create(creationCandidate);

        var newStudent = await studentsRepository.Create(studentToCreate);

        return newStudent;
    }

    public async Task<Student> UpdateAsync(int id, StudentUpdateCandidate updateCandidate)
    {
        var validationResult = await studentUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var student = await studentsRepository.GetByIdAsync(id);

        student.UserId = updateCandidate.UserId;
        
        var newStudent = await studentsRepository.UpdateAsync(student);
        
        return newStudent;
    }

    public async Task DeleteAsync(int id)
    {
        await studentsRepository.DeleteAsync(id);
    }
}