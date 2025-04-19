using SaM.Modules.Teachers.Ports.OutBounds.Models;
using SaM.Modules.Teachers.Web.Candidates;

namespace SaM.Modules.Teachers.Web.Abstractions;

public interface ITeacherApplication
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int id);
    Task<Teacher> Create(TeacherCandidate candidate);
}