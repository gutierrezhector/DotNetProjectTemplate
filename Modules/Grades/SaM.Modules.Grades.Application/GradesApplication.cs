using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Grades.Application.Factories;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Ports.InBounds;
using SaM.Modules.Grades.Web.Abstractions;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application;

public class GradesApplication(
    IGradesRepository gradesRepository,
    IValidator<GradeCreationCandidate> gradeCreationCandidateValidator,
    IValidator<GradeUpdateCandidate> gradeUpdateCandidateValidator
) : IGradesApplication
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        return await gradesRepository.GetByIdAsync(id);
    }

    public async Task<Grade> CreateAsync(GradeCreationCandidate creationCandidate)
    {
        var validationResult = await gradeCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var gradeToCreate = GradesFactory.Create(creationCandidate);
        var newGrade = await gradesRepository.CreateAsync(gradeToCreate);

        return newGrade;
    }

    public async Task<Grade> UpdateAsync(int id, GradeUpdateCandidate updateCandidate)
    {
        var validationResult = await gradeUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var grade = await gradesRepository.GetByIdAsync(id);
        
        grade.Notation = updateCandidate.Notation;
        grade.StudentId = updateCandidate.StudentId;
        grade.ExamId = updateCandidate.ExamId;
        
        var newUser = await gradesRepository.UpdateAsync(grade);
        
        return newUser;
    }

    public async Task DeleteAsync(int id)
    {
        await gradesRepository.DeleteAsync(id);
    }
}