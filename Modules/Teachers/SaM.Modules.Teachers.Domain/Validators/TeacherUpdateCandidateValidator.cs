using FluentValidation;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Domain.Validators;

public record TeacherUpdateWrapper(ITeacherUpdateCandidate Candidate, Teacher Entity);

public class TeacherUpdateCandidateValidator : AbstractValidator<TeacherUpdateWrapper>
{
    public TeacherUpdateCandidateValidator()
    {
        RuleFor(wrapper => wrapper.Candidate.SchoolSubject)
            .NotEqual(SchoolSubject.Undefined)
            .WithMessage("SchoolSubject needs to be defined.");
        
        RuleFor(wrapper => wrapper)
            .Must(NotTryToUpdateUserId)
            .WithMessage("Can't update UserId, create a new teacher.");
    }

    private static bool NotTryToUpdateUserId(TeacherUpdateWrapper wrapper)
    {
        return wrapper.Candidate.UserId == wrapper.Entity.UserId;
    }
}
