using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Entities;

namespace SaM.Modules.Grades.Ports.InBounds.Factories;

public interface IGradeFactory
{
    IGrade Create(IGradeCreationCandidate creationCandidate);
}