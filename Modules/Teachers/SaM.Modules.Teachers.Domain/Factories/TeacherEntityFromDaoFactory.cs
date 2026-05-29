using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Teachers.Domain.Factories;

public class TeacherEntityFromDaoFactory(
    Mapper<TeacherDao, Teacher> teacherDaoToExamEntityMapper,
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFromDaoFactory<Teacher, TeacherDao>
{
    public override Teacher CreateFromDao(TeacherDao from)
    {
        var teacher = teacherDaoToExamEntityMapper.MapNonNullable(from);
        teacher.User = userDaoToUserEntityMapper.MapNullable(from.User);

        return teacher;
    }
}
