using SaM.Core.Abstractions.Mappers;
using SaM.Modules.Exams.Application.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Application.Mappers;

public class ExamCreationCandidateMapper : Mapper<IExamCreationPayload, IExamCreationCandidate>
{
    public override IExamCreationCandidate MapNonNullable(IExamCreationPayload from)
    {
        return new ExamCreationCandidate
        {
            Title = from.Title,
            StartDate = from.StartDate,
            EndDate = from.EndDate,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
        };
    }
}