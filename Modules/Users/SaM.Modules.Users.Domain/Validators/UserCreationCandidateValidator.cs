using FluentValidation;
using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Modules.Users.Domain.Validators;

public class UserCreationCandidateValidator : AbstractValidator<IUserCreationCandidate>
{
    public UserCreationCandidateValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.LastName).NotEmpty();
    }
}