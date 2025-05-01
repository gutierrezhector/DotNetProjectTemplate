using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Students;

namespace SaM.Modules.Grades.Domain.Mappers;

public class GradeDaoToGradeEntityMapper(
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper
) : Mapper<GradeDao, Grade>
{
    public override Grade MapNonNullable(GradeDao from)
    {
        return new Grade
        {
            Id = from.Id,
            Notation = from.Notation,
            StudentId = from.StudentId,
            Student = studentDaoToStudentEntityMapper.MapNullable(from.Student),
            ExamId = from.ExamId,
            Exam = examDaoToExamEntityMapper.MapNullable(from.Exam),
        };
    }
}