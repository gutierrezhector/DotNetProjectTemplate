using FluentValidation;
using SaM.Core.Exceptions.Implementations;
using SaM.Modules.Exams.Application.Factories;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Ports.InBounds;
using SaM.Modules.Exams.Web.Abstractions;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Application;

public class ExamsApplication(
    IExamsRepository repository,
    IValidator<ExamCreationCandidate> examCreationCandidateValidator,
    IValidator<ExamUpdateCandidate> examUpdateCandidateValidator
) : IExamsApplication
{
    public async Task<List<Exam>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Exam> CreateAsync(ExamCreationCandidate creationCandidate)
    {
        var validationResult = await examCreationCandidateValidator.ValidateAsync(creationCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var examToCreate = ExamEntityFactory.Create(creationCandidate);

        return await repository.CreateAsync(examToCreate);
    }

    public async Task<Exam> UpdateAsync(int id, ExamUpdateCandidate updateCandidate)
    {
        var validationResult = await examUpdateCandidateValidator.ValidateAsync(updateCandidate);
        if (!validationResult.IsValid)
        {
            throw new ValidationResultException(validationResult);
        }
        
        var exam = await repository.GetByIdAsync(id);

        exam.Title = updateCandidate.Title;
        exam.StartDate = updateCandidate.StartDate;
        exam.EndDate = updateCandidate.EndDate;
        exam.MaxPoints = updateCandidate.MaxPoints;
        exam.ResponsibleTeacherId = updateCandidate.ResponsibleTeacherId;
        
        return await repository.UpdateAsync(exam);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}