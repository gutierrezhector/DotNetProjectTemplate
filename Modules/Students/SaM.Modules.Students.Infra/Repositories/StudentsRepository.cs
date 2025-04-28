using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Infra.Factories;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Infra.Repositories;

public class StudentsRepository(
    SaMDbContext dbContext,
    Mapper<StudentDao, IStudent> studentDaoToStudentMapper
) : BaseRepository(dbContext), IStudentsRepository
{
    public async Task<List<IStudent>> GetAllAsync()
    {
        var studentsDao = await Set<StudentDao>()
            .ToListAsync();

        return studentDaoToStudentMapper.Map(studentsDao);
    }

    public async Task<IStudent> GetByIdAsync(int studentId)
    {
        var studentDao = await GetByIdInternal(studentId);

        return studentDaoToStudentMapper.Map(studentDao);
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await Set<StudentDao>()
            .AnyAsync(s => s.UserId == userId);
    }

    public async Task<IStudent> Create(IStudent studentToCreate)
    {
        var newStudentDao = StudentFactory.Create(studentToCreate);

        DbContext.Add(newStudentDao);
        await SaveChangesAsync();

        return studentToCreate;
    }

    public async Task<IStudent> UpdateAsync(int id, IStudentUpdateCandidate updateCandidate)
    {
        var studentDaoToUpdate = await GetByIdInternal(id);

        studentDaoToUpdate.UpdateFromCandidate(updateCandidate);

        await SaveChangesAsync();

        return studentDaoToStudentMapper.Map(studentDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var studentDao = await GetByIdInternal(id);

        Set<StudentDao>().Remove(studentDao);

        await SaveChangesAsync();
    }

    private async Task<StudentDao> GetByIdInternal(int id)
    {
        var studentDao = await Set<StudentDao>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (studentDao == null)
        {
            throw new NotFoundException($"student with id '{id}' not found.");
        }

        return studentDao;
    }
}