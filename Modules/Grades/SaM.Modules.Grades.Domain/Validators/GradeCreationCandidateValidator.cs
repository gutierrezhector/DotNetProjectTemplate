using FluentValidation;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain.Validators;

public class GradeCreationCandidateValidator : AbstractValidator<IGradeCreationCandidate>
{
    public GradeCreationCandidateValidator(IExamsRepository examRepository)
    {
        RuleFor(x => x.Notation).NotEmpty();
    }
}