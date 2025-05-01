using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.InBounds.Factories;

namespace SaM.Modules.Teachers.Domain.Factories;

public class TeacherEntityFactory : ITeacherEntityFactory
{
    public Teacher Create(ITeacherCreationCandidate creationCandidate)
    {
        return new Teacher
        {
            SchoolSubject = creationCandidate.SchoolSubject,
            UserId = creationCandidate.UserId,
        };
    }
}