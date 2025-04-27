using SaM.Modules.Exams.Ports.InBounds.Candidates;
using SaM.Modules.Exams.Ports.InBounds.Entities;

namespace SaM.Modules.Exams.Ports.OutBounds.Repositories;

public interface IExamsRepository
{
    Task<List<IExam>> GetAllAsync();
    Task<IExam> GetByIdAsync(int id);
    Task<IExam> CreateAsync(IExam candidate);
    Task<IExam> UpdateAsync(int id, IExamUpdateCandidate exam);
    Task DeleteAsync(int id);
}