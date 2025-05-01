using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Students;

namespace SaM.Modules.Students.Domain.Mappers;

public class StudentDaoToStudentEntityMapper : Mapper<StudentDao, Student>
{
    public override Student MapNonNullable(StudentDao from)
    {
        return new Student
        {
            Id = from.Id,
            UserId = from.UserId,
        };
    }
}