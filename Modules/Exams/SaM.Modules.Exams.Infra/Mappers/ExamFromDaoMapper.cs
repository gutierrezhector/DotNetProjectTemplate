using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Teachers.Domain.Entities;

namespace SaM.Modules.Exams.Infra.Mappers;

public class ExamFromDaoMapper(
    Mapper<TeacherDao, Teacher> teacherFromDaoMapper
) : Mapper<ExamDao, Exam>
{
    public override Exam Map(ExamDao from)
    {
        return new Exam
        {
            Id = from.Id,
            StartDate = from.StartDate,
            EndDate = from.EndDate,
            Title = from.Title,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
            // TODO : manage null
            ResponsibleTeacher = teacherFromDaoMapper.Map(from.ResponsibleTeacher),
        };
    }
}