using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Domain.Factories;

public class ExamEntityFactory(
    Mapper<IExamCreationCandidate, Exam> examCreationCandidateToExamEntityMapper,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper,
    Mapper<TeacherDao, Teacher> teacherDaoToExamEntityMapper,
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper
) : EntityFactory<Exam,  ExamDao, IExamCreationCandidate>
{
    public override Exam CreateFromCandidate(IExamCreationCandidate creationCandidate)
    {
        return examCreationCandidateToExamEntityMapper.MapNonNullable(creationCandidate);
    }

    public override Exam CreateFromDao(ExamDao from)
    {
        var exam = examDaoToExamEntityMapper.MapNonNullable(from);
        exam.ResponsibleTeacher = teacherDaoToExamEntityMapper.MapNullable(from.ResponsibleTeacher);
        exam.Grades =  gradeDaoToGradeEntityMapper.MapNullable(from.Grades);

        return exam;
    }
}