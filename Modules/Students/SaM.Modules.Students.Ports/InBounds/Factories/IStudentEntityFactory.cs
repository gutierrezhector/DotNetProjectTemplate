using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Ports.InBounds.Factories;

public interface IStudentEntityFactory
{
    Student Create(IStudentCreationCandidate candidate);
}