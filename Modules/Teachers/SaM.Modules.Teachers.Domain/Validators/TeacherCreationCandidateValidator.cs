using FluentValidation;
using SaM.Core.Types.Enums;
using SaM.Modules.Students.Ports.OutBounds.Repositories;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Domain.Validators;

public class TeacherCreationCandidateValidator : AbstractValidator<ITeacherCreationCandidate>
{
    public TeacherCreationCandidateValidator(
        ITeachersRepository teachersRepository,
        IStudentsRepository studentRepository
    )
    {
        RuleFor(c => c.SchoolSubject)
            .NotEqual(SchoolSubject.Undefined)
            .WithMessage("SchoolSubject needs to be defined.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await teachersRepository.ExistAsync(userId))
            .WithMessage("Teacher already exists.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await studentRepository.ExistAsync(userId))
            .WithMessage("User is already a student.");
    }
}