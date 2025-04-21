using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Domain.Entities;

namespace SaM.Modules.Students.Infra.Factories;

public static class StudentFactory
{
    public static StudentDao Create(Student student)
    {
        return new StudentDao
        {
            UserId = student.UserId,
        };
    }
}