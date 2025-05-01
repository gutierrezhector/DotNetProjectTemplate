using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Teachers;

namespace SaM.Modules.Exams.Domain.Mappers;

public class ExamPopulator(
    Mapper<TeacherDao, Teacher> teacherDaoToExamEntityMapper,
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper
)
{
    public Exam Assemble(ExamDao from)
    {
        var exam = examDaoToExamEntityMapper.MapNonNullable(from);
        
        exam.ResponsibleTeacher = teacherDaoToExamEntityMapper.MapNullable(from.ResponsibleTeacher);
        exam.Grades =  gradeDaoToGradeEntityMapper.MapNullable(from.Grades);
        return exam;
    }
}

public class ExamDaoToExamEntityMapper : Mapper<ExamDao, Exam>
{
    public override Exam MapNonNullable(ExamDao from)
    {
        return new Exam
        {
            Id = from.Id,
            StartDate = from.StartDate,
            EndDate = from.EndDate,
            Title = from.Title,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
            // ResponsibleTeacher = teacherDaoToExamEntityMapper.MapNullable(from.ResponsibleTeacher),
            // Grades = gradeDaoToGradeEntityMapper.MapNullable(from.Grades),
        };
    }
}