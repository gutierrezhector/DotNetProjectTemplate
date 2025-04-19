using SaM.Core.Abstractions.Mappers;
using SaM.Database.Data.Daos.Exams;
using SaM.Database.Data.Daos.Teachers;
using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Teachers.Ports.OutBounds.Models;

namespace SaM.Modules.Exams.Infra.Mappers;

public class ExamsMapper(
    Mapper<TeacherDao, Teacher> teacherMapper
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
            MinPoints = from.MinPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
            // TODO : manage null
            ResponsibleTeacher = teacherMapper.Map(from.ResponsibleTeacher),
        };
    }
}