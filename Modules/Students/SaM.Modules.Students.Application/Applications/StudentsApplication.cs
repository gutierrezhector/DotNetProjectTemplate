using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Domain.Factories;
using SaM.Modules.Students.Domain.Validators;
using SaM.Modules.Students.Ports.InBounds.Applications;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Payloads;
using SaM.Modules.Students.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Application.Applications;

public class StudentsApplication(
    IStudentsRepository studentsRepository,
    StudentEntityFactory studentEntityFactory,
    IValidator<IStudentCreationCandidate> studentCreationCandidateValidator,
    IValidator<StudentUpdateWrapper> studentUpdateCandidateValidator,
    Mapper<IStudentCreationPayload, IStudentCreationCandidate> studentCreationCandidateMapper,
    Mapper<IStudentUpdatePayload, IStudentUpdateCandidate> studentUpdateCandidateMapper
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

    public async Task<Student> CreateAsync(IStudentCreationPayload creationPayload)
    {
        var creationCandidate = studentCreationCandidateMapper.MapNonNullable(creationPayload);
        var validationResult = await studentCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var studentToCreate = studentEntityFactory.CreateFromCandidate(creationCandidate);

        return await studentsRepository.Create(studentToCreate);
    }

    public async Task<Student> UpdateAsync(int id, IStudentUpdatePayload updatePayload)
    {
        var updateCandidate = studentUpdateCandidateMapper.MapNonNullable(updatePayload);
        var currentStudent = await studentsRepository.GetByIdAsync(id);
        var validationResult = await studentUpdateCandidateValidator.ValidateAsync(new StudentUpdateWrapper(updateCandidate, currentStudent));
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }

        var newStudent = await studentsRepository.UpdateAsync(id, updateCandidate);

        return newStudent;
    }

    public async Task DeleteAsync(int id)
    {
        await studentsRepository.DeleteAsync(id);
    }
}