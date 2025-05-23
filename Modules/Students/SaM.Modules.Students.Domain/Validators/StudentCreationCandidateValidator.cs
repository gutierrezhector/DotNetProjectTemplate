using FluentValidation;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Students.Domain.Validators;

public class StudentCreationCandidateValidator : AbstractValidator<IStudentCreationCandidate>
{
    public StudentCreationCandidateValidator(
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