using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
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
    Mapper<GradeDao, Grade> gradeDaoToGradeEntityMapper
) : BaseRepository(dbContext), IGradesRepository
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        var grade = await GetByIdInternal(id);
        return gradeDaoToGradeEntityMapper.MapNonNullable(grade);
    }

    public async Task<Grade> CreateAsync(Grade grade)
    {
        var newGradeDao = GradeDaoFactory.Create(grade);

        DbContext.Add(newGradeDao);

        await SaveChangesAsync();

        return grade;
    }

    public async Task<Grade> UpdateAsync(int id, IGradeUpdateCandidate updateCandidate)
    {
        var gradeDaoToUpdate = await GetByIdInternal(id);

        GradeDaoFactory.Update(gradeDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return gradeDaoToGradeEntityMapper.MapNonNullable(gradeDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var gradeDao = await GetByIdInternal(id);

        Set<GradeDao>().Remove(gradeDao);

        await SaveChangesAsync();
    }

    private async Task<GradeDao> GetByIdInternal(int id)
    {
        var studentDao = await SetIncludeAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (studentDao == null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return studentDao;
    }
    
    private IQueryable<GradeDao> SetIncludeAll()
    {
        return Set<GradeDao>()
            .Include(g => g.Exam)
            .Include(g => g.Student)
            .AsQueryable();
    }
}