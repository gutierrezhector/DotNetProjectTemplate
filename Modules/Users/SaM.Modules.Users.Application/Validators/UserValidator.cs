using FluentValidation;
using SaM.Modules.Users.Web.Candidates;

namespace SaM.Modules.Users.Application.Validators;

public class UserValidator : AbstractValidator<UserCandidate>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.LastName).NotEmpty();
    }
}