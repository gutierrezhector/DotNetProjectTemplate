using SaM.Modules.Exams.Ports.InBounds.Entities;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Ports.InBounds.Applications;

public interface IExamsApplication
{
    Task<List<IExam>> GetAllAsync();
    Task<IExam> GetByIdAsync(int id);
    Task<IExam> CreateAsync(IExamCreationPayload creationPayload);
    Task<IExam> UpdateAsync(int id, IExamUpdatePayload toCandidate);
    Task DeleteAsync(int id);
}