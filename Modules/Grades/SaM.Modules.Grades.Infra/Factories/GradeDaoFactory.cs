using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Domain.Entities;

namespace SaM.Modules.Grades.Infra.Factories;

public static class GradeDaoFactory
{
    public static GradeDao Create(Grade grade)
    {
        return new GradeDao
        {
            Notation = grade.Notation,
            ExamId = grade.ExamId,
            StudentId = grade.StudentId,
        };
    }
}