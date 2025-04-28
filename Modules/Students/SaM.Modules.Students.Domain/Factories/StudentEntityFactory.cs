using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Factories;

namespace SaM.Modules.Students.Domain.Factories;

public class StudentEntityFactory : IStudentEntityFactory
{
    public IStudent Create(IStudentCreationCandidate candidate)
    {
        return new Student
        {
            UserId = candidate.UserId,
        };
    }
}