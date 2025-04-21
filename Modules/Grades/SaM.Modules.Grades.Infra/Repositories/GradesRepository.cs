using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Infra.Factories;
using SaM.Modules.Grades.Ports.InBounds;

namespace SaM.Modules.Grades.Infra.Repositories;

public class GradesRepository(
    SaMDbContext dbContext,
    Mapper<GradeDao, Grade> gradeDaoToEntityMapper
) : BaseRepository(dbContext), IGradesRepository
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        var grade =  await GetByIdInternal(id);
        return gradeDaoToEntityMapper.Map(grade);
    }

    public async Task<Grade> CreateAsync(Grade grade)
    {
        var newGradeDao = GradeDaoFactory.Create(grade);
        
        DbContext.Add(newGradeDao);
        
        await SaveChangesAsync();

        return grade;
    }

    public async Task<Grade> UpdateAsync(Grade grade)
    {
        var gradeDaoToUpdate = await GetByIdInternal(grade.Id);
        
        gradeDaoToUpdate.UpdateFromDomainEntity(grade);
        
        await SaveChangesAsync();

        return grade;
    }

    public async Task DeleteAsync(int id)
    {
        var gradeDao = await GetByIdInternal(id);

        Set<GradeDao>().Remove(gradeDao);
        
        await SaveChangesAsync();
    }
    
    private async Task<GradeDao> GetByIdInternal(int id)
    {
        var studentDao = await Set<GradeDao>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (studentDao == null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return studentDao;
    }
}