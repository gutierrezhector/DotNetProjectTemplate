using SaM.Core.Types.Entities.Grades;
using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Ports.InBounds.Applications;

public interface IGradesApplication
{
    Task<Grade> GetByIdAsync(int id);
    Task<Grade> CreateAsync(IGradeCreationPayload creationPayload);
    Task<Grade> UpdateAsync(int id, IGradeUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}