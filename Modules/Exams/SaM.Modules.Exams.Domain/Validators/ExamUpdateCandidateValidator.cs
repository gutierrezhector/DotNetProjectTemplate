using FluentValidation;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Exams.Domain.Validators;

public record TeacherUpdateWrapper(IExamUpdateCandidate Candidate, Exam Entity);

public class ExamUpdateCandidateValidator : AbstractValidator<TeacherUpdateWrapper>
{
    public ExamUpdateCandidateValidator(ITeachersRepository teachersRepository)
    {
        RuleFor(wrapper => wrapper.Candidate.Title)
            .NotEmpty()
            .WithMessage("Title must not be empty.");

        RuleFor(wrapper => wrapper.Candidate.MaxPoints)
            .LessThanOrEqualTo(20)
            .WithMessage("MaxPoints must not be superior to 20.");

        RuleFor(wrapper => wrapper.Candidate.StartDate)
            .LessThan(wrapper => wrapper.Candidate.EndDate)
            .WithMessage("StartDate must be less than EndDate.");

        RuleFor(wrapper => wrapper.Candidate.ResponsibleTeacherId)
            .MustAsync(async (responsibleTeacherId, _) => await teachersRepository.ExistAsync(responsibleTeacherId))
            .WithMessage("Responsible Teacher must exists.");
    }
}