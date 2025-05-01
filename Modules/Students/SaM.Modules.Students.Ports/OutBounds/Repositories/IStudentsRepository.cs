using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Ports.OutBounds.Repositories;

public interface IStudentsRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int studentId);
    Task<bool> ExistAsync(int userId);
    Task<Student> Create(Student studentToCreate);
    Task<Student> UpdateAsync(int id, IStudentUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}