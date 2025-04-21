using SaM.Modules.Students.Domain.Entities;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Web.Abstractions;

public interface IStudentsApplication
{
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int studentId);
    Task<Student> CreateAsync(StudentCreationCandidate creationCandidate);
    Task<Student> UpdateAsync(int id, StudentUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}