using SaM.Modules.Exams.Domain.Entities;

namespace SaM.Modules.Exams.Ports.InBounds;

public interface IExamsRepository
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);
    Task<Exam> CreateAsync(Exam candidate);
    Task<Exam> UpdateAsync(Exam exam);
    Task DeleteAsync(int id);
}