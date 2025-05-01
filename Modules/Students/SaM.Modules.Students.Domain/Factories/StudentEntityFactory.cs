using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Factories;

namespace SaM.Modules.Students.Domain.Factories;

public class StudentEntityFactory : IStudentEntityFactory
{
    public Student Create(IStudentCreationCandidate candidate)
    {
        return new Student
        {
            UserId = candidate.UserId,
        };
    }
}