using SaM.Modules.Teachers.Ports.InBounds.Entities;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Ports.InBounds.Applications;

public interface ITeachersApplication
{
    Task<List<ITeacher>> GetAllAsync();
    Task<ITeacher> GetByIdAsync(int id);
    Task<ITeacher> Create(ITeacherCreationPayload creationPayload);
    Task<ITeacher> UpdateAsync(int id, ITeacherUpdatePayload updatePayload);
    Task DeleteAsync(int id);
}