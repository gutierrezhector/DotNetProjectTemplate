using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Domain.Mappers;

public class StudentDaoToEntityMapper(
    Mapper<UserDao, IUser> userFromDaoMapper
) : Mapper<StudentDao, IStudent>
{
    public override IStudent MapNonNullable(StudentDao from)
    {
        return new Student
        {
            Id = from.Id,
            UserId = from.UserId,
            User = userFromDaoMapper.MapNullable(from.User),
        };
    }
}