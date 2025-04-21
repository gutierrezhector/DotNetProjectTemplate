using SaM.Modules.Teachers.Domain.Entities;

namespace SaM.Modules.Teachers.Ports.InBounds;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int id);
    Task<Teacher> Create(Teacher newTeacher);
    Task<bool> ExistAsync(int id);
    Task<Teacher> UpdateAsync(Teacher teacher);
    Task DeleteAsync(int id);
}