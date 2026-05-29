using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Core.SharedKernel.Entities.Users;
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
            SchoolSubject = from.SchoolSubject,
            UserId = from.UserId,
            User = userDaoToUserEntityMapper.MapNullable(from.User),
        };
    }
}