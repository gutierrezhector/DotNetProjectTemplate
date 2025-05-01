using SaM.Core.Abstractions.Factories;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Infra.Factories;

public class StudentDaoFactory : DaoFactory<StudentDao, Student, IStudentUpdateCandidate>
{
    public override StudentDao CreateFromEntity(Student entity)
    {
        return new StudentDao
        {
            UserId = entity.UserId,
        };
    }

    public override void UpdateFromCandidate(StudentDao daoToUpdate, IStudentUpdateCandidate updateCandidate)
    {
        daoToUpdate.UserId = updateCandidate.UserId;
    }
}