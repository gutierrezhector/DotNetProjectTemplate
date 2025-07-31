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
        RuleFor(wrapper => wrapper.Candidate.MaxPoints).LessThanOrEqualTo(20);
        RuleFor(wrapper => wrapper.Candidate.StartDate).NotEmpty();
        RuleFor(wrapper => wrapper.Candidate.StartDate).LessThan(wrapper => wrapper.Candidate.EndDate);
        RuleFor(wrapper => wrapper.Candidate.ResponsibleTeacherId)
            .MustAsync(async (responsibleTeacherId, _) => await teachersRepository.ExistAsync(responsibleTeacherId))
            .When(wrapper => wrapper.Entity.ResponsibleTeacherId != wrapper.Candidate.ResponsibleTeacherId)
            .WithMessage("Responsible Teacher must exists.");
    }
}