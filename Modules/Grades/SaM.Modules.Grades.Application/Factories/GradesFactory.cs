using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application.Factories;

public static class GradesFactory
{
    public static Grade Create(GradeCreationCandidate creationCandidate)
    {
        return new Grade
        {
            Notation = creationCandidate.Notation,
            ExamId = creationCandidate.ExamId,
            StudentId = creationCandidate.StudentId
        };
    }
}