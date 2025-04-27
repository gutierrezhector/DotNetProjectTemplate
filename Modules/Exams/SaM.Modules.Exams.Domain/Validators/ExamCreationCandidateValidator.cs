using FluentValidation;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Exams.Domain.Validators;

public class ExamCreationCandidateValidator : AbstractValidator<IExamCreationCandidate>
{
    public ExamCreationCandidateValidator(ITeacherRepository teacherRepository)
    {
        RuleFor(e => e.MaxPoints).LessThanOrEqualTo(20);
        RuleFor(e => e.StartDate).NotEmpty();
        RuleFor(e => e.StartDate).LessThan(e => e.EndDate);
        RuleFor(e => e.ResponsibleTeacherId)
            .MustAsync(async (responsibleTeacherId, _) => await teacherRepository.ExistAsync(responsibleTeacherId))
            .WithMessage("Responsible Teacher must exists.");
    }
}