using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Ports.InBounds.Applications;

public interface ITeachersApplication
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(int id);
    Task<Teacher> Create(ITeacherCreationPayload creationPayload);
    Task<Teacher> UpdateAsync(int id, ITeacherUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}