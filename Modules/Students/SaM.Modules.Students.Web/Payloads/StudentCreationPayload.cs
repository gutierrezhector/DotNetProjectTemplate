using SaM.Modules.Students.Ports.InBounds.Payloads;

namespace SaM.Modules.Students.Web.Payloads;

public record StudentCreationPayload : IStudentCreationPayload
{
    public int UserId { get; init; }
}