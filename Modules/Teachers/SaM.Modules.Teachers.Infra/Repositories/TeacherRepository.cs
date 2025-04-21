using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Infra.Factories;
using SaM.Modules.Teachers.Ports.InBounds;

namespace SaM.Modules.Teachers.Infra.Repositories;

public class TeacherRepository(
    SaMDbContext dbContext,
    Mapper<TeacherDao, Teacher> mapper
) : BaseRepository(dbContext), ITeacherRepository
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        var teachers = await Set<TeacherDao>()
            .ToListAsync();

        return mapper.Map(teachers);
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        var teacher = await Set<TeacherDao>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (teacher == null)
        {
            throw new NotFoundException($"teacher with id '{id}' not found.'");
        }

        return mapper.Map(teacher);
    }

    public async Task<Teacher> Create(Teacher newTeacher)
    {
        var newTeacherDao = TeacherDaoFactory.Create(newTeacher);
        
        DbContext.Add(newTeacherDao);
        await SaveChangesAsync();

        newTeacher.Id = newTeacherDao.Id;
        
        return newTeacher;
    }

    public async Task<Teacher> UpdateAsync(Teacher teacher)
    {
        var teacherDaoToUpdate = await GetByIdInternal(teacher.Id);
        
        teacherDaoToUpdate.UpdateFromDomainEntity(teacher);
        
        await SaveChangesAsync();

        return teacher;
    }

    public async Task DeleteAsync(int id)
    {
        var teacherDao = await GetByIdInternal(id);

        Set<TeacherDao>().Remove(teacherDao);
        
        await SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await Set<TeacherDao>()
            .AnyAsync(t => t.UserId == id);
    }
    
    private async Task<TeacherDao> GetByIdInternal(int id)
    {
        var teacherDao = await Set<TeacherDao>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (teacherDao == null)
        {
            throw new NotFoundException($"teacher with id '{id}' not found.");
        }

        return teacherDao;
    }
}