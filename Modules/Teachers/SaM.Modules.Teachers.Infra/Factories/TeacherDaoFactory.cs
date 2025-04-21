using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Entities;

namespace SaM.Modules.Teachers.Infra.Factories;

public static class TeacherDaoFactory
{
    public static TeacherDao Create(Teacher teacher)
    {
        return new TeacherDao
        {
            Id = teacher.Id,
            SchoolSubject = teacher.SchoolSubject,
            UserId = teacher.UserId,
        };
    }
}