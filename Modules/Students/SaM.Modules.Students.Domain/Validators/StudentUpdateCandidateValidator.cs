using FluentValidation;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Students.Domain.Validators;

public record TeacherUpdateWrapper(IStudentUpdateCandidate Candidate, Student Entity);

public class StudentUpdateCandidateValidator : AbstractValidator<TeacherUpdateWrapper>
{
    public StudentUpdateCandidateValidator(
        ITeacherRepository teacherRepository,
        IStudentsRepository studentRepository
    )
    {
        RuleFor(wrapper => wrapper.Candidate.UserId)
            .MustAsync(async (userId, _) => !await teacherRepository.ExistAsync(userId))
            .When(wrapper => wrapper.Entity.UserId != wrapper.Candidate.UserId)
            .WithMessage("Teacher already exists.");

        RuleFor(wrapper => wrapper.Candidate.UserId)
            .MustAsync(async (userId, _) => !await studentRepository.ExistAsync(userId))
            .When(wrapper => wrapper.Entity.UserId != wrapper.Candidate.UserId)
            .WithMessage("User is already a student.");
    }
}