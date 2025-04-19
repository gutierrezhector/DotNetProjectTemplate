using SaM.Modules.Grades.Ports.OutBounds.Models;

namespace SaM.Modules.Grades.Application.Ports.InBounds;

public interface IGradesRepository
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(Grade grade);
}