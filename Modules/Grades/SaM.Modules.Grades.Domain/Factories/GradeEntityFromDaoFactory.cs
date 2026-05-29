using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.Entities.Students;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Students;

namespace SaM.Modules.Grades.Domain.Factories;

public class GradeEntityFromDaoFactory(
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper,
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper
) : EntityFromDaoFactory<Grade, GradeDao>
{
    public override Grade CreateFromDao(GradeDao from)
    {
        var grade = gradeDaoToGradeEntityMapper.MapNonNullable(from);

        grade.Exam = examDaoToExamEntityMapper.MapNullable(from.Exam);
        grade.Student = studentDaoToStudentEntityMapper.MapNullable(from.Student);

        return grade;
    }
}
