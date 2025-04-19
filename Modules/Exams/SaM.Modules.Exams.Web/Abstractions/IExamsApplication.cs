using SaM.Modules.Exams.Ports.OutBounds.Models;
using SaM.Modules.Exams.Web.Candidates;

namespace SaM.Modules.Exams.Web.Abstractions;

public interface IExamsApplication
{
    Task<List<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(int id);

    Task<Exam> Create(ExamCandidate candidate);
}