using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Web.Payloads;

public record StudentPayload
{
    public int UserId { get; init; }

    public StudentCandidate ToCandidate()
    {
        return new StudentCandidate
        {
            UserId = UserId,
        };
    }
}