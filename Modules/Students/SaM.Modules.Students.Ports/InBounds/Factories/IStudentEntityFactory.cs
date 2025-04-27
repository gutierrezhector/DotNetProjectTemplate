using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Ports.InBounds.Factories;

public interface IStudentEntityFactory
{
    IStudent Create(IStudentCreationCandidate candidate);
}