using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Data.Daos.Students;
using SaM.Modules.Students.Ports.InBounds;
using SaM.Modules.Students.Ports.OutBounds.Models;

namespace SaM.Modules.Students.Infra.Repositories;

public class StudentsRepository(
    SaMDbContext dbContext,
    Mapper<StudentDao, Student> studentDaoToStudentMapper
) : IStudentsRepository
{
    public async Task<List<Student>> GetAllAsync()
    {
        var studentsDao = await Set()
            .ToListAsync();

        return studentDaoToStudentMapper.Map(studentsDao);
    }

    public async Task<Student?> GetByIdAsync(int studentId)
    {
        var studentDao = await Set()
            .Where(u => u.Id == studentId)
            .FirstOrDefaultAsync();

        if (studentDao == null)
            throw new NotFoundException($"student with id '{studentId}' not found.");

        return studentDaoToStudentMapper.Map(studentDao);
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await Set()
            .AnyAsync(s => s.UserId == userId);
    }

    public async Task<Student> Create(Student studentToCreate)
    {
        dbContext.Add(studentToCreate);
        await dbContext.SaveChangesAsync();

        return studentToCreate;
    }

    private DbSet<StudentDao> Set()
    {
        return dbContext.Set<StudentDao>();
    }
}