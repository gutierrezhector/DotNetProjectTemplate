using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Teachers.Infra.Mappers;

public class TeacherFromDaoMapper(Mapper<UserDao, User> userFromDaoMapper) : Mapper<TeacherDao, Teacher>
{
    public override Teacher Map(TeacherDao from)
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