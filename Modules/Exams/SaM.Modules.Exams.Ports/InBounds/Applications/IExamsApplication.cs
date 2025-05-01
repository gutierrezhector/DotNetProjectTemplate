using SaM.Core.Types.Entities.Exams;
using SaM.Modules.Exams.Ports.InBounds.Payloads;

namespace SaM.Modules.Exams.Ports.InBounds.Applications;

public interface IExamsApplication
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);
    Task<Exam> CreateAsync(IExamCreationPayload creationPayload);
    Task<Exam> UpdateAsync(int id, IExamUpdatePayload toCandidate);
    Task DeleteAsync(int id);
}