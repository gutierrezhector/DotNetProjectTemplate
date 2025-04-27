using SaM.Modules.Users.Ports.InBounds.Candidates;

namespace SaM.Database.Core.Daos.Users;

public class UserDao
{
    public int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public void UpdateFromCandidate(IUserUpdateCandidate updateCandidate)
    {
        FirstName = updateCandidate.FirstName;
        LastName = updateCandidate.LastName;
    }
}