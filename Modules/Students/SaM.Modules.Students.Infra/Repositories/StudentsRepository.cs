using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Students;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Students;
using SaM.Modules.Students.Infra.Factories;
using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.OutBounds.Repositories;

namespace SaM.Modules.Students.Infra.Repositories;

public class StudentsRepository(
    SaMDbContext dbContext,
    Mapper<StudentDao, Student> studentDaoToStudentEntityMapper
) : BaseRepository(dbContext), IStudentsRepository
{
    public async Task<List<Student>> GetAllAsync()
    {
        var studentsDao = await Set<StudentDao>()
            .ToListAsync();

        return studentDaoToStudentEntityMapper.MapNonNullable(studentsDao);
    }

    public async Task<Student> GetByIdAsync(int studentId)
    {
        var studentDao = await GetByIdInternal(studentId);

        return studentDaoToStudentEntityMapper.MapNonNullable(studentDao);
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await Set<StudentDao>()
            .AnyAsync(s => s.UserId == userId);
    }

    public async Task<Student> Create(Student studentToCreate)
    {
        var newStudentDao = StudentDaoFactory.Create(studentToCreate);

        DbContext.Add(newStudentDao);
        await SaveChangesAsync();

        return studentToCreate;
    }

    public async Task<Student> UpdateAsync(int id, IStudentUpdateCandidate updateCandidate)
    {
        var studentDaoToUpdate = await GetByIdInternal(id);

        StudentDaoFactory.Update(studentDaoToUpdate,  updateCandidate);

        await SaveChangesAsync();

        return studentDaoToStudentEntityMapper.MapNonNullable(studentDaoToUpdate);
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