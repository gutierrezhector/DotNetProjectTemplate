using SaM.Modules.Exams.Domain.Entities;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Web.Abstractions;

public interface IExamsApplication
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);
    Task<Exam> CreateAsync(ExamCreationCandidate candidate);
    Task<Exam> UpdateAsync(int id, ExamUpdateCandidate toCandidate);
    Task DeleteAsync(int id);
}