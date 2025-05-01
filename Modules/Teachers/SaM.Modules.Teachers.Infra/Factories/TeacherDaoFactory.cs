using SaM.Core.Abstractions.Factories;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Infra.Factories;

public  class TeacherDaoFactory : DaoFactory<TeacherDao, Teacher, ITeacherUpdateCandidate>
{
    public override TeacherDao CreateFromEntity(Teacher entity)
    {
        return new TeacherDao
        {
            Id = entity.Id,
            SchoolSubject = entity.SchoolSubject,
            UserId = entity.UserId,
        };
    }

    public override void UpdateFromCandidate(TeacherDao daoToUpdate, ITeacherUpdateCandidate updateCandidate)
    {
        daoToUpdate.UserId = updateCandidate.UserId;
        daoToUpdate.SchoolSubject = updateCandidate.SchoolSubject;
    }
}