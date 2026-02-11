using SaM.Core.Types.Entities.Grades;

namespace SaM.Modules.Grades.Ports.InBounds.Candidates;

public record GradeUpdateWrapper(IGradeUpdateCandidate Candidate, Grade Entity);