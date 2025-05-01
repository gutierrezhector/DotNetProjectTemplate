using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Candidates;

namespace SaM.Modules.Exams.Ports.OutBounds.Repositories;

public interface IExamsRepository
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);
    Task<Exam> CreateAsync(Exam candidate);
    Task<Exam> UpdateAsync(int id, IExamUpdateCandidate exam);
    Task DeleteAsync(int id);
}