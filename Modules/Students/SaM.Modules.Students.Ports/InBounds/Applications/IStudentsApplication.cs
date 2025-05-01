using SaM.Core.Types.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Ports.InBounds.Applications;

public interface IStudentsApplication
{
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int studentId);
    Task<Student> CreateAsync(IStudentCreationPayload creationPayload);
    Task<Student> UpdateAsync(int id, IStudentUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}