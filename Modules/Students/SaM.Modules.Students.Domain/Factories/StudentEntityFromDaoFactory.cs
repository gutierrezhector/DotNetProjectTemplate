using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Core.SharedKernel.Entities.Users;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Users;

namespace SaM.Modules.Students.Domain.Factories;

public class StudentEntityFromDaoFactory(
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper,
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFromDaoFactory<Student, StudentDao>
{
    public override Student CreateFromDao(StudentDao from)
    {
        var student = studentDaoToStudentEntityMapper.MapNonNullable(from);

        student.User = userDaoToUserEntityMapper.MapNullable(from.User);

        return student;
    }
}
