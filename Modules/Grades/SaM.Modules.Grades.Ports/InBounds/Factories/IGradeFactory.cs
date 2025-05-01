using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Ports.InBounds.Factories;

public interface IGradeFactory
{
    Grade Create(IGradeCreationCandidate creationCandidate);
}