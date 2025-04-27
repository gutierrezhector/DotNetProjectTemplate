using SaM.Modules.Students.Ports.InBounds.Entities;
using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Ports.InBounds.Applications;

public interface IStudentsApplication
{
    Task<List<IStudent>> GetAllAsync();
    Task<IStudent> GetByIdAsync(int studentId);
    Task<IStudent> CreateAsync(IStudentCreationPayload creationPayload);
    Task<IStudent> UpdateAsync(int id, IStudentUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}