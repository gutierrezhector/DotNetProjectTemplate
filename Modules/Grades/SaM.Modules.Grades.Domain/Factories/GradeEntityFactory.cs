using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Types.Entities.Exams;
using SaM.Core.Types.Entities.Grades;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Domain.Factories;

public class GradeEntityFactory(
    Mapper<IGradeCreationCandidate, Grade> gradeCreationCandidateToGradeEntityMapper,
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper,
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper
) : EntityFactory<Grade,  GradeDao, IGradeCreationCandidate>
{
    public override Grade CreateFromCandidate(IGradeCreationCandidate creationCandidate)
    {
        return gradeCreationCandidateToGradeEntityMapper.MapNonNullable(creationCandidate);
    }

    public override Grade CreateFromDao(GradeDao from)
    {
        var grade = gradeDaoToGradeEntityMapper.MapNonNullable(from);

        grade.Exam = examDaoToExamEntityMapper.MapNullable(from.Exam);
        grade.Student = studentDaoToStudentEntityMapper.MapNullable(from.Student);

        return grade;
    }
}