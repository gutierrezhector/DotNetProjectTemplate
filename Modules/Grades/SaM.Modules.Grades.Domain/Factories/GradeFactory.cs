using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Factories;

namespace SaM.Modules.Grades.Domain.Factories;

public class GradeFactory : IGradeFactory
{
    public Grade Create(IGradeCreationCandidate creationCandidate)
    {
        return new Grade
        {
            Notation = creationCandidate.Notation,
            ExamId = creationCandidate.ExamId,
            StudentId = creationCandidate.StudentId,
        };
    }
}