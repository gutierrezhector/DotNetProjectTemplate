using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Candidates;

namespace SaM.Modules.Grades.Ports.OutBounds.Repositories;

public interface IGradesRepository
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(Grade grade);
    Task<Grade> UpdateAsync(int id, IGradeUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}