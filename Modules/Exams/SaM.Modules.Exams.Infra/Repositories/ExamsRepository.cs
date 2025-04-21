using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Abstractions.Repository;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Core.Daos.Exams;
using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Infra.Factories;
using SaM.Modules.Exams.Ports.InBounds;

namespace SaM.Modules.Exams.Infra.Repositories;

public class ExamsRepository(
    SaMDbContext dbContext, 
    Mapper<ExamDao, Exam> mapper
) : BaseRepository(dbContext), IExamsRepository
{
    public async Task<List<Exam>> GetAllAsync()
    {
        var exams = await Set<ExamDao>().ToListAsync();

        return mapper.Map(exams);
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        var exam =  await GetByIdInternal(id);

        return mapper.Map(exam);
    }

    public async Task<Exam> CreateAsync(Exam examToCreate)
    {
        var newExamDao = ExamDaoFactory.Create(examToCreate);
        
        dbContext.Add(newExamDao);
        
        await SaveChangesAsync();

        examToCreate.Id = newExamDao.Id;
        
        return examToCreate;
    }

    public async Task<Exam> UpdateAsync(Exam exam)
    {
        var examDaoToUpdate = await GetByIdInternal(exam.Id);
        
        examDaoToUpdate.UpdateFromDomainEntity(exam);
        
        await SaveChangesAsync();

        return exam;
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