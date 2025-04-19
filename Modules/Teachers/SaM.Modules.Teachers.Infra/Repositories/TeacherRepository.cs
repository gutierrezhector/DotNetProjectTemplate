using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Data.Daos.Teachers;
using SaM.Modules.Teachers.Ports.InBounds;
using SaM.Modules.Teachers.Ports.OutBounds.Models;

namespace SaM.Modules.Teachers.Infra.Repositories;

public class TeacherRepository(
    SaMDbContext dbContext,
    Mapper<TeacherDao, Teacher> mapper
) : ITeacherRepository
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        var teachers = await Set()
            .ToListAsync();

        return mapper.Map(teachers);
    }

    public async Task<Teacher> GetByIdAsync(int teacherId)
    {
        var teacher = await Set()
            .Where(t => t.Id == teacherId)
            .FirstOrDefaultAsync();

        if (teacher == null)
        {
            throw new NotFoundException($"teacher with id '{teacherId}' not found.'");
        }

        return mapper.Map(teacher);
    }

    public async Task<Teacher> Create(Teacher newTeacher)
    {
        dbContext.Add(newTeacher);
        await dbContext.SaveChangesAsync();

        return newTeacher;
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await Set()
            .AnyAsync(t => t.UserId == userId);
    }


    private DbSet<TeacherDao> Set()
    {
        return dbContext.Set<TeacherDao>();
    }
}