using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Application.Factories;

public static class StudentFactory
{
    public static Student Create(StudentCreationCandidate candidate)
    {
        return new Student
        {
            UserId = candidate.UserId
        };
    }
}