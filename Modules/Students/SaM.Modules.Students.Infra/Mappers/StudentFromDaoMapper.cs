using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Users.Domain.Entities;

namespace SaM.Modules.Students.Infra.Mappers;

public class StudentFromDaoMapper(Mapper<UserDao, User> userFromDaoMapper) : Mapper<StudentDao, Student>
{
    public override Student Map(StudentDao from)
    {
        return new Student
        {
            Id = from.Id,
            UserId = from.UserId,
            // TODO : manage null
            User = userFromDaoMapper.Map(from.User)
        };
    }
}