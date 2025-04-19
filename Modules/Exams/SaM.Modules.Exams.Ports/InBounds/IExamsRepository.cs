
using SaM.Modules.Exams.Ports.OutBounds.Models;

namespace SaM.Modules.Exams.Ports.InBounds;

public interface IExamsRepository
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);
    Task<Exam> CreateAsync(Exam candidate);
}