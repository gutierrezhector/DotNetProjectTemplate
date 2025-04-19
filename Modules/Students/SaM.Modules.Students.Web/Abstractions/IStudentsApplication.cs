using SaM.Modules.Students.Ports.OutBounds.Models;
using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Web.Abstractions;

public interface IStudentsApplication
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int studentId);
    Task<Student> Create(StudentCandidate candidate);
}