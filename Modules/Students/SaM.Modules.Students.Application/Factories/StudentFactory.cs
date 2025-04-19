using SaM.Modules.Students.Ports.OutBounds.Models;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Application.Factories;

public static class StudentFactory
{
    public static Student Create(StudentCandidate candidate)
    {
        return new Student
        {
            UserId = candidate.UserId
        };
    }
}