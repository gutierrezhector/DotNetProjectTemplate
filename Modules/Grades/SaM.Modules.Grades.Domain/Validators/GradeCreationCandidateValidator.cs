using FluentValidation;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;

namespace SaM.Modules.Grades.Domain.Validators;

public class GradeCreationCandidateValidator : AbstractValidator<IGradeCreationCandidate>
{
    private readonly IGradesRepository _gradesRepository;
    private readonly IExamsRepository _examsRepository;

    public GradeCreationCandidateValidator(
        IGradesRepository gradesRepository,
        IExamsRepository examsRepository
    )
    {
        _gradesRepository = gradesRepository;
        _examsRepository = examsRepository;

        RuleFor(c => c.Notation)
            .Must(NotBeNegative)
            .WithMessage("Notation must not be negative.");
        
        RuleFor(c => c)
            .MustAsync(NotationBeInferiorOrEqualToMaxPoints)
            .WithMessage("Grade notation must be inferior or equal to exam max points.");
        
        RuleFor(c => c)
            .MustAsync(ExamMustNotAlreadyHaveAGradeForStudent)
            .WithMessage("This exam already have a grade for this student.");
    }

    private bool NotBeNegative(decimal notation)
    {
        return notation > 0;
    }

    private async Task<bool> ExamMustNotAlreadyHaveAGradeForStudent(IGradeCreationCandidate candidate, CancellationToken _)
    {
        return !await _gradesRepository.ExistAsync(candidate.ExamId, candidate.StudentId);
    }

    private async Task<bool> NotationBeInferiorOrEqualToMaxPoints(IGradeCreationCandidate candidate, CancellationToken _)
    {
        var exam = await _examsRepository.GetByIdAsync(candidate.ExamId);
        return candidate.Notation <= exam.MaxPoints;
    }
}