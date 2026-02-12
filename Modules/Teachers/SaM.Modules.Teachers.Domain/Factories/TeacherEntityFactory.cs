using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Teachers;
using SaM.Core.Types.Entities.Users;
using SaM.Database.Core.Daos.Teachers;
using SaM.Database.Core.Daos.Users;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Domain.Factories;

public class TeacherEntityFactory(
    Mapper<ITeacherCreationCandidate, Teacher> teacherCreationCandidateToTeacherEntityMapper,
    Mapper<TeacherDao, Teacher> teacherDaoToExamEntityMapper,
    Mapper<UserDao, User> userDaoToUserEntityMapper
) : EntityFactory<Teacher, TeacherDao, ITeacherCreationCandidate>
{
    public override Teacher CreateFromCandidate(ITeacherCreationCandidate creationCandidate)
    {
        return teacherCreationCandidateToTeacherEntityMapper.MapNonNullable(creationCandidate);
    }

    public override Teacher CreateFromDao(TeacherDao from)
    {
        var teacher = teacherDaoToExamEntityMapper.MapNonNullable(from);
        teacher.User = userDaoToUserEntityMapper.MapNullable(from.User);

        return teacher;
    }
}