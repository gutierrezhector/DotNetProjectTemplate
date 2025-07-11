using FluentValidation;
using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Domain.Validators;

public record StudentUpdateWrapper(IStudentUpdateCandidate Candidate, Student Entity);

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
