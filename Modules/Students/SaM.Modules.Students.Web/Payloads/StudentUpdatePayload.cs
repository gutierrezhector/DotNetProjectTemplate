using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Web.Payloads;

public record StudentUpdatePayload : IStudentUpdatePayload
{
    public int UserId { get; init; }
}