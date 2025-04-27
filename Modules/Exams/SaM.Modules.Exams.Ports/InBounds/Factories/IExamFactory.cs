using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Ports.InBounds.Factories;

public interface IExamFactory
{
    IExam Create(IExamCreationCandidate candidate);
}