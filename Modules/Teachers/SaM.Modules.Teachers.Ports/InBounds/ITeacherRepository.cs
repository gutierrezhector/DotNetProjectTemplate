using SaM.Modules.Teachers.Ports.OutBounds.Models;

namespace SaM.Modules.Teachers.Ports.InBounds;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int teacherId);
    Task<Teacher> Create(Teacher newTeacher);
    Task<bool> ExistAsync(int userId);
}