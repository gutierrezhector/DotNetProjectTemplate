using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.SharedKernel.Entities.Exams;
using SaM.Core.SharedKernel.Entities.Grades;
using SaM.Core.SharedKernel.Entities.Teachers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Teachers;

namespace SaM.Modules.Exams.Domain.Factories;

public class ExamEntityFromDaoFactory(
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper,
    Mapper<TeacherDao, Teacher> teacherDaoToExamEntityMapper,
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper
) : EntityFromDaoFactory<Exam, ExamDao>
{
    public override Exam CreateFromDao(ExamDao from)
    {
        var exam = examDaoToExamEntityMapper.MapNonNullable(from);
        exam.ResponsibleTeacher = teacherDaoToExamEntityMapper.MapNullable(from.ResponsibleTeacher);
        exam.Grades =  gradeDaoToGradeEntityMapper.MapNullable(from.Grades);

        return exam;
    }
}
