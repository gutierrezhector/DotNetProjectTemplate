using FluentValidation;
using SaM.Modules.Exams.Ports.InBounds;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application.Validators;

public class GradeUpdateCandidateValidator : AbstractValidator<GradeUpdateCandidate>
{
    public GradeUpdateCandidateValidator(IExamsRepository examRepository)
    {
        RuleFor(x => x.Notation).NotEmpty();
    }
}