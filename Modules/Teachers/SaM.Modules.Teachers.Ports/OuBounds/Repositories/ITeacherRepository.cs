using SaM.Modules.Teachers.Ports.InBounds.Entities;

namespace SaM.Modules.Teachers.Ports.OuBounds.Repositories;

public interface ITeacherRepository
{
    Task<List<ITeacher>> GetAllAsync();
    Task<ITeacher> GetByIdAsync(int id);
    Task<ITeacher> Create(ITeacher newTeacher);
    Task<bool> ExistAsync(int id);
    Task<ITeacher> UpdateAsync(ITeacher teacher);
    Task DeleteAsync(int id);
}