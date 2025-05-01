using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Teachers.Domain.Mappers;

public class TeacherDaoToTeacherEntityMapper(
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : Mapper<TeacherDao, Teacher>
{
    public override Teacher MapNonNullable(TeacherDao from)
    {
        return new Teacher
        {
            Id = from.Id,
            UserId = from.UserId,
            User = userDaoToUserEntityMapper.MapNullable(from.User),
            SchoolSubject = from.SchoolSubject,
        };
    }
}