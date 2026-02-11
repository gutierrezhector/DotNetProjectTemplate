using SaM.Core.Types.Entities.Teachers;
using SaM.Modules.Teachers.Ports.InBounds.Candidates;

namespace SaM.Modules.Teachers.Ports.InBounds;

public record TeacherUpdateWrapper(ITeacherUpdateCandidate Candidate, Teacher Entity);