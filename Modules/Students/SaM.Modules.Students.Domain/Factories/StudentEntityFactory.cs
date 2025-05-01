using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Students;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Students;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Domain.Factories;

public class StudentEntityFactory(
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper,
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFactory<Student,  StudentDao, IStudentCreationCandidate>
{
    public override Student CreateFromCandidate(IStudentCreationCandidate creationCandidate)
    {
        return new Student
        {
            UserId = creationCandidate.UserId,
        };
    }

    public override Student CreateFromDao(StudentDao from)
    {
        var student = studentDaoToStudentEntityMapper.MapNonNullable(from);

        student.User = userDaoToUserEntityMapper.MapNullable(from.User);
        
        return student;
    }
}