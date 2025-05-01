using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Teachers;

namespace SaM.Modules.Teachers.Domain.Mappers;

public class TeacherDaoToTeacherEntityMapper : Mapper<TeacherDao, Teacher>
{
    public override Teacher MapNonNullable(TeacherDao from)
    {
        return new Teacher
        {
            Id = from.Id,
            UserId = from.UserId,
            SchoolSubject = from.SchoolSubject,
        };
    }
}