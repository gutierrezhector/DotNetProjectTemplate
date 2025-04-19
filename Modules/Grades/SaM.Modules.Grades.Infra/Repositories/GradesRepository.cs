using Microsoft.EntityFrameworkCore;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Modules.Grades.Application.Ports.InBounds;
using SaM.Modules.Grades.Ports.OutBounds.Models;

namespace SaM.Modules.Grades.Infra.Repositories;

public class GradesRepository(
    SaMDbContext dbContext
) : IGradesRepository
{
    public async Task<Grade> GetByIdAsync(int id)
    {
        var grade = await Set()
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();

        if (grade is null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return grade;
    }

    public async Task<Grade> CreateAsync(Grade grade)
    {
        dbContext.Add(grade);
        await dbContext.SaveChangesAsync();

        return grade;
    }

    private DbSet<Grade> Set()
    {
        return dbContext.Set<Grade>();
    }
}