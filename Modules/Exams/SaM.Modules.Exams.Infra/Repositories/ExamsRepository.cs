using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Infra.Factories;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Infra.Repositories;

public class ExamsRepository(
    SaMDbContext dbContext,
    Mapper<ExamDao, IExam> mapper
) : BaseRepository(dbContext), IExamsRepository
{
    public async Task<List<IExam>> GetAllAsync()
    {
        var exams = await Set<ExamDao>().ToListAsync();

        return mapper.MapNonNullable(exams);
    }

    public async Task<IExam> GetByIdAsync(int id)
    {
        var exam = await GetByIdInternal(id);

        return mapper.MapNonNullable(exam);
    }

    public async Task<IExam> CreateAsync(IExam examToCreate)
    {
        var newExamDao = ExamDaoFactory.Create(examToCreate);

        DbContext.Add(newExamDao);

        await SaveChangesAsync();

        examToCreate.Id = newExamDao.Id;

        return examToCreate;
    }

    public async Task<IExam> UpdateAsync(int id, IExamUpdateCandidate updateCandidate)
    {
        var examDaoToUpdate = await GetByIdInternal(id);

        examDaoToUpdate.UpdateFromCandidate(updateCandidate);

        await SaveChangesAsync();

        return mapper.MapNonNullable(examDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var examDao = await GetByIdInternal(id);

        Set<ExamDao>().Remove(examDao);

        await SaveChangesAsync();
    }

    private async Task<ExamDao> GetByIdInternal(int id)
    {
        var examDao = await Set<ExamDao>()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (examDao == null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return examDao;
    }
}