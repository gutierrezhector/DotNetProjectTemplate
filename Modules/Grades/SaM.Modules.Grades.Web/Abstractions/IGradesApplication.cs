using SaM.Modules.Grades.Ports.OutBounds.Models;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Web.Abstractions;

public interface IGradesApplication
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(GradeCandidate candidate);
}