using SaM.Modules.Grades.Domain.Entities;
using SaM.Modules.Grades.Web.Candidates;

namespace SaM.Modules.Grades.Web.Abstractions;

public interface IGradesApplication
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(GradeCreationCandidate creationCandidate);
    Task<Grade> UpdateAsync(int id, GradeUpdateCandidate updateCandidate);
    Task DeleteAsync(int id);
}