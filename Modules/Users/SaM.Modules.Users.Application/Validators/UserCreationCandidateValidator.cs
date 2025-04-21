using FluentValidation;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application.Validators;

public class UserCreationCandidateValidator : AbstractValidator<UserCreationCandidate>
{
    public UserCreationCandidateValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.LastName).NotEmpty();
    }
}