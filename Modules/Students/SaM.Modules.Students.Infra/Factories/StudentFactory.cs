using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Infra.Factories;

public static class StudentFactory
{
    public static StudentDao Create(IStudent student)
    {
        return new StudentDao
        {
            UserId = student.UserId,
        };
    }
}