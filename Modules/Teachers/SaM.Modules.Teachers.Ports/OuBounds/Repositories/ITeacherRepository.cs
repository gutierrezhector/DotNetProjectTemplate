using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Ports.OuBounds.Repositories;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int id);
    Task<Teacher> Create(Teacher newTeacher);
    Task<bool> ExistAsync(int id);
    Task<Teacher> UpdateAsync(int id, ITeacherUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}