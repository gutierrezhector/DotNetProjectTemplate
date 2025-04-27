using SaM.Core.Types.Enums;
using SaM.Modules.Teachers.Ports.InBounds.Payloads;

namespace SaM.Modules.Teachers.Web.Payloads;

public record TeacherUpdatePayload : ITeacherUpdatePayload
{
    public SchoolSubject SchoolSubject { get; init; }
    public int UserId { get; init; }
}