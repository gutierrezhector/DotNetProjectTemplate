using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Entities;

namespace SaM.Modules.Teachers.Ports.InBounds.Factories;

public interface ITeacherEntityFactory
{
    ITeacher Create(ITeacherCreationCandidate creationCandidate);
}