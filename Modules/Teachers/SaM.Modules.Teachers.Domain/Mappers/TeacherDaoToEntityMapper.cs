using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Users.Ports.InBounds.Entities;

namespace SaM.Modules.Teachers.Domain.Mappers;

public class TeacherDaoToEntityMapper(
    Mapper<UserDao, IUser> userFromDaoMapper
) : Mapper<TeacherDao, ITeacher>
{
    public override ITeacher Map(TeacherDao from)
    {
        return new Teacher
        {
            Id = from.Id,
            UserId = from.UserId,
            // TODO : manage null
            User = userFromDaoMapper.Map(from.User),
            SchoolSubject = from.SchoolSubject,
        };
    }
}