using FluentValidation;
using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;

namespace SaM.Modules.Grades.Domain.Validators;

public record GradeUpdateWrapper(IGradeUpdateCandidate Candidate, Grade Entity);

public class GradeUpdateCandidateValidator : AbstractValidator<GradeUpdateWrapper>
{
    private readonly IExamsRepository _examsRepository;
    private readonly IGradesRepository _gradesRepository;

    public GradeUpdateCandidateValidator(
        IGradesRepository gradesRepository,
        IExamsRepository examsRepository
    )
    {
        _gradesRepository = gradesRepository;
        _examsRepository = examsRepository;

        RuleFor(w => w.Candidate.Notation)
            .Must(NotBeNegative)
            .WithMessage("Notation must not be negative.");

        RuleFor(c => c)
            .MustAsync(ExamMustNotAlreadyHaveAGradeForStudent)
            .WithMessage("This exam already have a grade for this student.");

        RuleFor(c => c)
            .MustAsync(BeInferiorOrEqualToMaxPoints)
            .WithMessage("Grade notation must be inferior or equal to exam max points.");

        RuleFor(w => w)
            .Must(NotTryToUpdateExamId)
            .WithMessage("Can't change exam of grade, delete the grade and create a new one.");

        RuleFor(w => w)
            .Must(NotTryToUpdateStudentId)
            .WithMessage("Can't change student of grade, delete the grade and create a new one.");
    }

    private static bool NotBeNegative(decimal notation)
    {
        return notation > 0;
    }

    private static bool NotTryToUpdateExamId(GradeUpdateWrapper wrapper)
    {
        return wrapper.Candidate.ExamId == wrapper.Entity.ExamId;
    }

    private static bool NotTryToUpdateStudentId(GradeUpdateWrapper wrapper)
    {
        return wrapper.Candidate.StudentId == wrapper.Entity.StudentId;
    }

    private async Task<bool> ExamMustNotAlreadyHaveAGradeForStudent(GradeUpdateWrapper wrapper, CancellationToken _)
    {
        return !await _gradesRepository.ExistAsync(wrapper.Candidate.ExamId, wrapper.Candidate.StudentId);
    }

    private async Task<bool> BeInferiorOrEqualToMaxPoints(GradeUpdateWrapper wrapper, CancellationToken _)
    {
        var exam = await _examsRepository.GetByIdAsync(wrapper.Candidate.ExamId);
        return wrapper.Candidate.Notation <= exam.MaxPoints;
    }
}