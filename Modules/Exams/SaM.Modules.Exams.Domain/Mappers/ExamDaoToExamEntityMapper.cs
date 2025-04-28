using SaM.Core.Abstractions.Mappers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Domain.Mappers;

public class ExamDaoToExamEntityMapper(
    Mapper<TeacherDao, ITeacher> teacherDaoToExamEntityMapper,
    Mapper<GradeDao, IGrade> gradeFromDaoMapper
) : Mapper<ExamDao, IExam>
{
    public override IExam MapNonNullable(ExamDao from)
    {
        return new Exam
        {
            Id = from.Id,
            StartDate = from.StartDate,
            EndDate = from.EndDate,
            Title = from.Title,
            MaxPoints = from.MaxPoints,
            ResponsibleTeacherId = from.ResponsibleTeacherId,
            ResponsibleTeacher = teacherDaoToExamEntityMapper.MapNullable(from.ResponsibleTeacher),
            Grades = gradeFromDaoMapper.MapNullable(from.Grades),
        };
    }
}