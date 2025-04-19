using SaM.Modules.Grades.Ports.OutBounds.Models;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Application.Factories;

public static class GradesFactory
{
    public static Grade Create(GradeCandidate candidate)
    {
        return new Grade
        {
            Notation = candidate.Notation,
            ExamId = candidate.ExamId,
        };
    }
}