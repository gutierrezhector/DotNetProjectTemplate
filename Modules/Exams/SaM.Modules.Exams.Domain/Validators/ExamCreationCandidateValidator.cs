using FluentValidation;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Exams.Domain.Validators;

public class ExamCreationCandidateValidator : AbstractValidator<IExamCreationCandidate>
{
    public ExamCreationCandidateValidator(ITeacherRepository teacherRepository)
    {
        RuleFor(e => e.Title)
            .NotEmpty()
            .WithMessage("Title must not be empty.");
        
        RuleFor(e => e.MaxPoints)
            .LessThanOrEqualTo(20)
            .WithMessage("MaxPoints must not be superior to 20.");
        
        RuleFor(e => e.StartDate)
            .LessThan(e => e.EndDate)
            .WithMessage("StartDate must be less than EndDate.");
        
        RuleFor(e => e.ResponsibleTeacherId)
            .MustAsync(async (responsibleTeacherId, _) => await teacherRepository.ExistAsync(responsibleTeacherId))
            .WithMessage("Responsible Teacher must exists.");
    }
}