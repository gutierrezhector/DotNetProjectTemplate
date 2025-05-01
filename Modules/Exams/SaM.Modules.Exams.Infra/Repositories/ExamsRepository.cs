using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Core.Types.Entities.Exams;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Exams;
using SaM.Database.Core.Daos.Grades;
using SaM.Modules.Exams.Infra.Factories;
using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.OutBounds.Repositories;

namespace SaM.Modules.Exams.Infra.Repositories;

public class ExamsRepository(
    SaMDbContext dbContext,
    Mapper<ExamDao, Exam> examDaoToExamEntityMapper
) : BaseRepository(dbContext), IExamsRepository
{
    
    public async Task<List<Exam>> GetAllAsync()
    {
        var exams = await SetIncludeAll()
            .ToListAsync();

        return examDaoToExamEntityMapper.MapNonNullable(exams);
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        var exam = await GetByIdInternal(id);

        return examDaoToExamEntityMapper.MapNonNullable(exam);
    }

    public async Task<Exam> CreateAsync(Exam examToCreate)
    {
        var newExamDao = ExamDaoFactory.Create(examToCreate);

        DbContext.Add(newExamDao);

        await SaveChangesAsync();

        examToCreate.Id = newExamDao.Id;

        return examToCreate;
    }

    public async Task<Exam> UpdateAsync(int id, IExamUpdateCandidate updateCandidate)
    {
        var examDaoToUpdate = await GetByIdInternal(id);

        ExamDaoFactory.Update(examDaoToUpdate, updateCandidate);

        await SaveChangesAsync();

        return examDaoToExamEntityMapper.MapNonNullable(examDaoToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var examDao = await GetByIdInternal(id);

        Set<ExamDao>().Remove(examDao);

        await SaveChangesAsync();
    }

    private async Task<ExamDao> GetByIdInternal(int id)
    {
        var examDao = await SetIncludeAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (examDao == null)
        {
            throw new NotFoundException($"grade with id '{id}' not found.");
        }

        return examDao;
    }

    private IIncludableQueryable<ExamDao, List<GradeDao>?> SetIncludeAll()
    {
        return Set<ExamDao>()
            .Include(e => e.Grades);
    }
}