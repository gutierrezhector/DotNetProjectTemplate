using FluentValidation;
using SaM.Modules.Exams.Web.Candidates;
using SaM.Modules.Teachers.Ports.InBounds;

namespace SaM.Modules.Exams.Application.Validators;

public class ExamCreationCandidateValidator : AbstractValidator<ExamCreationCandidate>
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