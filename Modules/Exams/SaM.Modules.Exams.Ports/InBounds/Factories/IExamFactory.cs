using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Ports.InBounds.Factories;

public interface IExamFactory
{
    Exam Create(IExamCreationCandidate candidate);
}