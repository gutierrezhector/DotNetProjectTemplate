using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Domain.Mappers;

public class ExamCreationCandidateToExamEntityMapper : Mapper<IExamCreationCandidate, Exam>
{
    public override Exam MapNonNullable(IExamCreationCandidate from)
    {
        return new Exam
        {
            Title = from.Title,
            EndDate = from.EndDate,
            StartDate = from.StartDate,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
        };
    }
}