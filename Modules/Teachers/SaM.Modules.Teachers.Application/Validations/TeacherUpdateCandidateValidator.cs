using FluentValidation;
using SaM.Core.Types.Enums;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Teachers.Ports.InBounds;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application.Validations;

public class TeacherUpdateCandidateValidator : AbstractValidator<TeacherUpdateCandidate>
{
    public TeacherUpdateCandidateValidator(
        ITeacherRepository teacherRepository,
        IStudentsRepository studentRepository
    )
    {
        RuleFor(c => c.SchoolSubject)
            .NotEqual(SchoolSubject.Undefined)
            .WithMessage("SchoolSubject needs to be defined.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await teacherRepository.ExistAsync(userId))
            .WithMessage("Teacher already exists.");

        RuleFor(c => c.UserId)
            .MustAsync(async (userId, _) => !await studentRepository.ExistAsync(userId))
            .WithMessage("User is already a student.");
    }
}