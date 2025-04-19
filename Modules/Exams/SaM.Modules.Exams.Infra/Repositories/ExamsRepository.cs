using Microsoft.EntityFrameworkCore;
using SaM.Core.Abstractions.Mappers;
using SaM.Core.Exceptions.Implementations;
using SaM.Database.Core;
using SaM.Database.Data.Daos.Exams;
using SaM.Modules.Exams.Ports.InBounds;
using SaM.Modules.Exams.Ports.OutBounds.Models;

namespace SaM.Modules.Exams.Infra.Repositories;

public class ExamsRepository(
    SaMDbContext dbContext, 
    Mapper<ExamDao, Exam> mapper
) : IExamsRepository
{
    public async Task<List<Exam>> GetAllAsync()
    {
        var exams = await dbContext.Set<ExamDao>().ToListAsync();

        return mapper.Map(exams);
    }

    public async Task<Exam> GetByIdAsync(int id)
    {
        var exam = await dbContext
            .Set<ExamDao>()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (exam is null)
        {
            throw new NotFoundException($"Exam with id '{id}' not found.");
        }

        return mapper.Map(exam);
    }

    public async Task<Exam> CreateAsync(Exam examToCreate)
    {
        dbContext.Add(examToCreate);
        await dbContext.SaveChangesAsync();

        return examToCreate;
    }
}