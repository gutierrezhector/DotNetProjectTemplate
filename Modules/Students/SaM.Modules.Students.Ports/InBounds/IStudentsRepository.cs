using SaM.Modules.Students.Domain.Entities;

namespace SaM.Modules.Students.Ports.InBounds;

public interface IStudentsRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int studentId);
    Task<bool> ExistAsync(int userId);
    Task<Student> Create(Student studentToCreate);
    Task<Student> UpdateAsync(Student student);
    Task DeleteAsync(int id);
}