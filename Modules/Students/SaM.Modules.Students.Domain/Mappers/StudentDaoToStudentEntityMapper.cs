using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Students.Domain.Mappers;

public class StudentDaoToStudentEntityMapper(
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : Mapper<StudentDao, Student>
{
    public override Student MapNonNullable(StudentDao from)
    {
        return new Student
        {
            Id = from.Id,
            UserId = from.UserId,
            User = userDaoToUserEntityMapper.MapNullable(from.User),
        };
    }
}