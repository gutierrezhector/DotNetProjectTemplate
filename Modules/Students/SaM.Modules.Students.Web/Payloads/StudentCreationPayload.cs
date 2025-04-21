using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Web.Payloads;

public record StudentCreationPayload
{
    public int UserId { get; init; }

    public StudentCreationCandidate ToCandidate()
    {
        return new StudentCreationCandidate
        {
            UserId = UserId,
        };
    }
}