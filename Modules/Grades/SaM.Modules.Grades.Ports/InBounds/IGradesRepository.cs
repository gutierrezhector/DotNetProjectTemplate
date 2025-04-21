using SaM.Modules.Grades.Domain.Entities;

namespace SaM.Modules.Grades.Ports.InBounds;

public interface IGradesRepository
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(Grade grade);
    Task<Grade> UpdateAsync(Grade grade);
    Task DeleteAsync(int id);
}