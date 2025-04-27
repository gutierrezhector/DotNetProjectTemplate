using SaM.Core.Types.Enums;

namespace SaM.Modules.Teachers.Ports.InBounds.Payloads;

public interface ITeacherUpdatePayload
{
    SchoolSubject SchoolSubject { get; init; }
    int UserId { get; init; }
}