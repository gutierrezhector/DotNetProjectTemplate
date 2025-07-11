using FluentValidation;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain.Validators;

public class UserUpdateCandidateValidator : AbstractValidator<IUserUpdateCandidate>
{
    public UserUpdateCandidateValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage("FirstName can't be empty");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("LastName can't be empty");
    }
}