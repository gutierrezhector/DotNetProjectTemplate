using FluentValidation;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Enums;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Domain.Validators;

public record TeacherUpdateWrapper(ITeacherUpdateCandidate Candidate, Teacher Entity);

public class TeacherUpdateCandidateValidator : AbstractValidator<TeacherUpdateWrapper>
{
    public TeacherUpdateCandidateValidator(
        ITeacherRepository teacherRepository,
        IStudentsRepository studentRepository
    )
    {
        RuleFor(wrapper => wrapper.Candidate.SchoolSubject)
            .NotEqual(SchoolSubject.Undefined)
            .WithMessage("SchoolSubject needs to be defined.");

        RuleFor(wrapper => wrapper.Candidate.UserId)
            .MustAsync(async (userId, _) => !await teacherRepository.ExistAsync(userId))
            .When(wrapper => wrapper.Entity.UserId != wrapper.Candidate.UserId)
            .WithMessage("Teacher already exists.");

        RuleFor(candidate => candidate.Candidate.UserId)
            .MustAsync(async (userId, _) => !await studentRepository.ExistAsync(userId))
            .When(wrapper => wrapper.Entity.UserId != wrapper.Candidate.UserId)
            .WithMessage("User is already a student.");
    }
}