using SaM.Modules.Students.Ports.InBounds.Candidates;
using SaM.Modules.Students.Ports.InBounds.Entities;

namespace SaM.Modules.Students.Ports.OutBounds.Repositories;

public interface IStudentsRepository
{
    Task<List<IStudent>> GetAllAsync();
    Task<IStudent> GetByIdAsync(int studentId);
    Task<bool> ExistAsync(int userId);
    Task<IStudent> Create(IStudent studentToCreate);
    Task<IStudent> UpdateAsync(int id, IStudentUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}