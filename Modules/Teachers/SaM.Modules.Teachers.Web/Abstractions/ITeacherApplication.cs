using SaM.Modules.Teachers.Domain.Entities;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Web.Abstractions;

public interface ITeacherApplication
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int id);
    Task<Teacher> Create(TeacherCreationCandidate creationCandidate);
    Task<Teacher> UpdateAsync(int id, TeacherUpdateCandidate toCandidate);
    Task DeleteAsync(int id);
}