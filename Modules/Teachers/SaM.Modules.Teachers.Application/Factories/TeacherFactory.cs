using SaM.Modules.Teachers.Ports.OutBounds.Models;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application.Factories;

public static class TeacherFactory
{
    public static Teacher Create(TeacherCandidate candidate)
    {
        return new Teacher
        {
            SchoolSubject = candidate.SchoolSubject,
            UserId = candidate.UserId
        };
    }
}