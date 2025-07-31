using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Teachers;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Teachers;
using SaM.Modules.Teachers.Domain.Factories;
using SaM.Modules.Teachers.Infra.Factories;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;
using SaM.Modules.Teachers.Ports.OuBounds.Repositories;

namespace SaM.Modules.Teachers.Infra.Repositories;

public class TeachersRepository(
    SaMDbContext dbContext,
    TeacherEntityFactory teacherEntityFactory,
    TeacherDaoFactory teacherDaoFactory
) : BaseRepository<TeacherDao>(dbContext), ITeachersRepository
{
    public async Task<List<Teacher>> GetAllAsync()
    {
        var teachers = await SetWithIncludes()
            .ToListAsync();

        return teacherEntityFactory.CreateFromDao(teachers);
    }

    public async Task<Teacher> GetByIdAsync(int id)
    {
        var teacher = await GetByIdInternalAsync(id);

        if (teacher == null)
        {
            throw new NotFoundException($"teacher with id '{id}' not found.'");
        }

        return teacherEntityFactory.CreateFromDao(teacher);
    }

    public async Task<Teacher> Create(Teacher newTeacher)
    {
        var newTeacherDao = teacherDaoFactory.CreateFromEntity(newTeacher);

        DbContext.Add(newTeacherDao);
        await SaveChangesAsync();

        newTeacher.Id = newTeacherDao.Id;

        return newTeacher;
    }

    public async Task<Teacher> UpdateAsync(int id, ITeacherUpdateCandidate updateCandidate)
    {
        var teacherDaoToUpdate = await GetByIdInternalAsync(id);

        teacherDaoFactory.UpdateFromCandidate(teacherDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return teacherEntityFactory.CreateFromDao(teacherDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var teacherDao = await GetByIdInternalAsync(id);

        SetWithoutIncludes().Remove(teacherDao);

        await SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await SetWithoutIncludes()
            .AnyAsync(t => t.UserId == id);
    }

    private async Task<TeacherDao> GetByIdInternalAsync(int id)
    {
        var teacherDao = await SetWithIncludes()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (teacherDao == null)
        {
            throw new NotFoundException($"teacher with id '{id}' not found.");
        }

        return teacherDao;
    }

    protected override IQueryable<TeacherDao> ApplyIncludes(DbSet<TeacherDao> set)
    {
        return set.Include(t => t.User)
            .Include(t => t.Exams);
    }
}