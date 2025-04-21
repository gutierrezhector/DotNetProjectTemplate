using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Application.Factories;

public static class TeacherFactory
{
    public static Teacher Create(TeacherCreationCandidate creationCandidate)
    {
        return new Teacher
        {
            SchoolSubject = creationCandidate.SchoolSubject,
            UserId = creationCandidate.UserId
        };
    }
}