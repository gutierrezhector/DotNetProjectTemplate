using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Domain.Factories;
using SaM.Modules.Exams.Infra.Factories;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Infra.Repositories;

public class ExamsRepository(
    SaMDbContext dbContext,
    ExamEntityFactory examEntityFactory,
    ExamDaoFactory examDaoFactory
) : BaseRepository<ExamDao>(dbContext), IExamsRepository
{
    public async Task<List<Exam>> GetAllAsync()
    {
        var exams = await SetWithIncludes()
            .ToListAsync();

        return examEntityFactory.CreateFromDao(exams);
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        var exam = await GetByIdInternal(id);

        return examEntityFactory.CreateFromDao(exam);
    }

    public async Task<Exam> CreateAsync(Exam examToCreate)
    {
        var newExamDao = examDaoFactory.CreateFromEntity(examToCreate);

        DbContext.Add(newExamDao);

        await SaveChangesAsync();

        var examCratedDao = await GetByIdInternal(newExamDao.Id);
        return examEntityFactory.CreateFromDao(examCratedDao);
    }

    public async Task<Exam> UpdateAsync(int id, IExamUpdateCandidate updateCandidate)
    {
        var examDaoToUpdate = await GetByIdInternal(id);

        examDaoFactory.UpdateFromCandidate(examDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return examEntityFactory.CreateFromDao(examDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var examDao = await GetByIdInternal(id);

        SetWithoutIncludes().Remove(examDao);

        await SaveChangesAsync();
    }

    private async Task<ExamDao> GetByIdInternal(int id)
    {
        var examDao = await SetWithIncludes()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (examDao == null)
        {
            throw new NotFoundException($"exam with id '{id}' not found.");
        }

        return examDao;
    }

    protected override IQueryable<ExamDao> ApplyIncludes(DbSet<ExamDao> set)
    {
        return set
            .Include(e => e.ResponsibleTeacher)
            .ThenInclude(e => e!.User)
            .Include(e => e.Grades);
    }
}