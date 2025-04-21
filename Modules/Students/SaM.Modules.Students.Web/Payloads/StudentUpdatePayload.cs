using SaM.Modules.Students.Web.Candidates;

namespace SaM.Modules.Students.Web.Payloads;

public record StudentUpdatePayload
{
    public int UserId { get; init; }

    public StudentUpdateCandidate ToCandidate()
    {
        return new StudentUpdateCandidate
        {
            UserId = UserId,
        };
    }
}