using SaM.Modules.Grades.Ports.InBounds.Candidates;
using SaM.Modules.Grades.Ports.InBounds.Entities;

namespace SaM.Modules.Grades.Ports.OutBounds.Repositories;

public interface IGradesRepository
{
    Task<IGrade> GetByIdAsync(int id);
    Task<IGrade> CreateAsync(IGrade grade);
    Task<IGrade> UpdateAsync(int id, IGradeUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}