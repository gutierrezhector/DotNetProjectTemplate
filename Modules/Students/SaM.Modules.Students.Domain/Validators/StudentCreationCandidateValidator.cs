using FluentValidation;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;
using SaM.Modules.Users.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Domain.Validators;

public class StudentCreationCandidateValidator : AbstractValidator<IStudentCreationCandidate>
{
    public StudentCreationCandidateValidator(
        IUsersRepository usersRepository,
        ITeachersRepository teachersRepository,
        IStudentsRepository studentsRepository
    )
    {
        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => await usersRepository.ExistAsync(userId))
            .WithMessage("User in candidate must exist to be associated with new student.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await teachersRepository.ExistAsync(userId))
            .WithMessage("User in candidate is a teacher.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await studentsRepository.ExistAsync(userId))
            .WithMessage("User in candidate is already a student.");
    }
}