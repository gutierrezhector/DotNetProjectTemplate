using FluentValidation;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Ports.InBounds.Applications;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Factories;
using SaM.Modules.Students.Ports.InBounds.Payloads;
using SaM.Modules.Students.Ports.OutBounds;
using SaM.Modules.Students.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Application.Applications;

public class StudentsApplication(
    IStudentsRepository studentsRepository,
    IStudentEntityFactory studentEntityFactory,
    IValidator<IStudentCreationCandidate> studentCreationCandidateValidator,
    IValidator<IStudentUpdateCandidate> studentUpdateCandidateValidator,
    Mapper<IStudentCreationPayload, IStudentCreationCandidate> studentCreationCandidateMapper,
    Mapper<IStudentUpdatePayload, IStudentUpdateCandidate> studentUpdateCandidateMapper
) : IStudentsApplication
{
    public async Task<List<IStudent>> GetAllAsync()
    {
        return await studentsRepository.GetAllAsync();
    }

    public async Task<IStudent> GetByIdAsync(int studentId)
    {
        return await studentsRepository.GetByIdAsync(studentId);
    }

    public async Task<IStudent> CreateAsync(IStudentCreationPayload creationPayload)
    {
        var creationCandidate = studentCreationCandidateMapper.Map(creationPayload);
        var validationResult = await studentCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var studentToCreate = studentEntityFactory.Create(creationCandidate);

        return await studentsRepository.Create(studentToCreate);
    }

    public async Task<IStudent> UpdateAsync(int id, IStudentUpdatePayload updatePayload)
    {
        var updateCandidate = studentUpdateCandidateMapper.Map(updatePayload);
        var validationResult = await studentUpdateCandidateValidator.ValidateAsync(updateCandidate);
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