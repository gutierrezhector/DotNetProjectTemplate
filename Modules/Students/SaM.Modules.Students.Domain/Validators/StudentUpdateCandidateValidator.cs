using FluentValidation;
using SaM.Modules.Students.Ports.InBounds;

namespace SaM.Modules.Students.Domain.Validators;

public class StudentUpdateCandidateValidator : AbstractValidator<StudentUpdateWrapper>
{
    public StudentUpdateCandidateValidator()
    {
        RuleFor(wrapper => wrapper)
            .Must(NotTryToUpdateUserId)
            .WithMessage("Can't update UserId, create a new student.");
    }

    private static bool NotTryToUpdateUserId(StudentUpdateWrapper wrapper)
    {
        return wrapper.Candidate.UserId == wrapper.Entity.UserId;
    }
}