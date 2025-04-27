using FluentValidation;
using SaM.Modules.Exams.Ports.OutBounds;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain.Validators;

public class GradeUpdateCandidateValidator : AbstractValidator<IGradeUpdateCandidate>
{
    public GradeUpdateCandidateValidator(IExamsRepository examRepository)
    {
        RuleFor(x => x.Notation).NotEmpty();
    }
}