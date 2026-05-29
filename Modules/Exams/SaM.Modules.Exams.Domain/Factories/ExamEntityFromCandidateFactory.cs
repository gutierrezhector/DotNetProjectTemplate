using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Domain.Factories;

public class ExamEntityFromCandidateFactory(
    Mapper<IExamCreationCandidate, Exam> examCreationCandidateToExamEntityMapper
) : EntityFromCandidateFactory<Exam, IExamCreationCandidate>
{
    public override Exam CreateFromCandidate(IExamCreationCandidate creationCandidate)
    {
        return examCreationCandidateToExamEntityMapper.MapNonNullable(creationCandidate);
    }
}
