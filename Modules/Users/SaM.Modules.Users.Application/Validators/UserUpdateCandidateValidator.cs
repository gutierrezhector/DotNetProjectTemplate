using FluentValidation;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application.Validators;

public class UserUpdateCandidateValidator : AbstractValidator<UserUpdateCandidate>
{
    public UserUpdateCandidateValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.LastName).NotEmpty();
    }
}