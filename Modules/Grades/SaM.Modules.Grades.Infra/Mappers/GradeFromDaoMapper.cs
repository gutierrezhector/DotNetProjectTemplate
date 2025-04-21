using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Students.Domain.Entities;

namespace SaM.Modules.Grades.Infra.Mappers;

public class GradeFromDaoMapper(
    Mapper<StudentDao, Student> studentFromDaoMapper,
    Mapper<ExamDao, Exam> examFromDaoMapper
) : Mapper<GradeDao, Grade>
{
    public override Grade Map(GradeDao from)
    {
        return new Grade
        {
            Id = from.Id,
            Notation = from.Notation,
            StudentId = from.StudentId,
            // TODO manage null
            Student = studentFromDaoMapper.Map(from.Student),
            ExamId = from.ExamId,
            Exam = examFromDaoMapper.Map(from.Exam)
        };
    }
}