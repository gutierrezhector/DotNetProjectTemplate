using SaM.Modules.Grades.Ports.InBounds.Entities;
using SaM.Modules.Grades.Ports.InBounds.Payloads;

namespace SaM.Modules.Grades.Ports.InBounds.Applications;

public interface IGradesApplication
{
    Task<IGrade> GetByIdAsync(int id);
    Task<IGrade> CreateAsync(IGradeCreationPayload creationPayload);
    Task<IGrade> UpdateAsync(int id, IGradeUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}