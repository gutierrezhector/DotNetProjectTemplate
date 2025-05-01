using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Ports.InBounds.Factories;

public interface ITeacherEntityFactory
{
    Teacher Create(ITeacherCreationCandidate creationCandidate);
}