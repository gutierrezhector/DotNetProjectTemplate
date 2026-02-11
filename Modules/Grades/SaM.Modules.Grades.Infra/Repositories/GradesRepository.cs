using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Factories;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Grades;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Infra.Factories;
using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.OutBounds.Repositories;

namespace SaM.Modules.Grades.Infra.Repositories;

public class GradesRepository(
    SaMDbContext dbContext,
    EntityFactory<Grade,  GradeDao, IGradeCreationCandidate> gradeEntityFactory,
    GradeDaoFactory gradeDaoFactory
) : BaseRepository<GradeDao>(dbContext), IGradesRepository
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        var grade = await GetByIdInternal(id);
        return gradeEntityFactory.CreateFromDao(grade);
    }

    public async Task<Grade> CreateAsync(Grade grade)
    {
        var newGradeDao = gradeDaoFactory.CreateFromEntity(grade);

        DbContext.Add(newGradeDao);

        await SaveChangesAsync();

        var gradeCreatedDao = await GetByIdInternal(newGradeDao.Id);
        return gradeEntityFactory.CreateFromDao(gradeCreatedDao);
    }

    public async Task<Grade> UpdateAsync(int id, IGradeUpdateCandidate updateCandidate)
    {
        var gradeDaoToUpdate = await GetByIdInternal(id);

        gradeDaoFactory.UpdateFromCandidate(gradeDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return gradeEntityFactory.CreateFromDao(gradeDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var gradeDao = await GetByIdInternal(id);

        SetWithoutIncludes().Remove(gradeDao);

        await SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(int examId, int studentId)
    {
        return await SetWithoutIncludes()
            .AnyAsync(g => g.ExamId == examId && g.StudentId == studentId);
    }

    private async Task<GradeDao> GetByIdInternal(int id)
    {
        var studentDao = await SetWithIncludes()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (studentDao == null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return studentDao;
    }

    protected override IQueryable<GradeDao> ApplyIncludes(DbSet<GradeDao> set)
    {
        return set.Include(g => g.Exam)
            .Include(g => g.Student);
    }
}