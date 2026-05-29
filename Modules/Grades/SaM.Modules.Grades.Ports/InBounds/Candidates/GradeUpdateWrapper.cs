using SaM.Core.SharedKernel.Entities.Grades;

namespace SaM.Modules.Grades.Ports.InBounds.Candidates;

public record GradeUpdateWrapper(IGradeUpdateCandidate Candidate, Grade Entity);