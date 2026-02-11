using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Factories;
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
    EntityFactory<Student,  StudentDao, IStudentCreationCandidate> studentEntityFactory,
    StudentDaoFactory studentDaoFactory
) : BaseRepository<StudentDao>(dbContext), IStudentsRepository
{
    public async Task<List<Student>> GetAllAsync()
    {
        var studentsDao = await SetWithIncludes()
            .ToListAsync();

        return studentEntityFactory.CreateFromDao(studentsDao);
    }

    public async Task<Student> GetByIdAsync(int studentId)
    {
        var studentDao = await GetByIdInternal(studentId);

        return studentEntityFactory.CreateFromDao(studentDao);
    }

    public async Task<bool> ExistAsync(int userId)
    {
        return await SetWithoutIncludes()
            .AnyAsync(s => s.UserId == userId);
    }

    public async Task<Student> Create(Student studentToCreate)
    {
        var newStudentDao = studentDaoFactory.CreateFromEntity(studentToCreate);

        DbContext.Add(newStudentDao);
        await SaveChangesAsync();

        var studentCreatedDao = await GetByIdInternal(newStudentDao.Id);
        return studentEntityFactory.CreateFromDao(studentCreatedDao);
    }

    public async Task<Student> UpdateAsync(int id, IStudentUpdateCandidate updateCandidate)
    {
        var studentDaoToUpdate = await GetByIdInternal(id);

        studentDaoFactory.UpdateFromCandidate(studentDaoToUpdate,  updateCandidate);

        await SaveChangesAsync();

        return studentEntityFactory.CreateFromDao(studentDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var studentDao = await GetByIdInternal(id);

        SetWithoutIncludes().Remove(studentDao);

        await SaveChangesAsync();
    }

    private async Task<StudentDao> GetByIdInternal(int id)
    {
        var studentDao = await SetWithIncludes()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (studentDao == null)
        {
            throw new NotFoundException($"student with id '{id}' not found.");
        }

        return studentDao;
    }

    protected override IQueryable<StudentDao> ApplyIncludes(DbSet<StudentDao> set)
    {
        return set.Include(s => s.User)
            .Include(s => s.Grades);
    }
}