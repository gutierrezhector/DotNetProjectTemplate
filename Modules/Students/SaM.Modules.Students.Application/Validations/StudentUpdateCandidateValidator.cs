using FluentValidation;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Web.Candidates;
using SaM.Modules.Teachers.Ports.InBounds;

namespace SaM.Modules.Students.Application.Validations;

public class StudentUpdateCandidateValidator : AbstractValidator<StudentUpdateCandidate>
{
    public StudentUpdateCandidateValidator(
        ITeacherRepository teacherRepository,
        IStudentsRepository studentRepository
    )
    {
        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await teacherRepository.ExistAsync(userId))
            .WithMessage("Teacher already exists.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await studentRepository.ExistAsync(userId))
            .WithMessage("User is already a student.");
    }
}