using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Grades.Domain.Mappers;

public class GradeDaoToEntityMapper(
    Mapper<StudentDao, IStudent> studentFromDaoMapper,
    Mapper<ExamDao, IExam> examFromDaoMapper
) : Mapper<GradeDao, IGrade>
{
    public override IGrade Map(GradeDao from)
    {
        return new Grade
        {
            Id = from.Id,
            Notation = from.Notation,
            StudentId = from.StudentId,
            // TODO manage null
            Student = studentFromDaoMapper.Map(from.Student),
            ExamId = from.ExamId,
            Exam = examFromDaoMapper.Map(from.Exam),
        };
    }
}