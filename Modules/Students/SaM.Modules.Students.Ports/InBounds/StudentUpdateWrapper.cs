using SaM.Core.SharedKernel.Entities.Students;
using SaM.Modules.Students.Ports.InBounds.Candidates;

namespace SaM.Modules.Students.Ports.InBounds;

public record StudentUpdateWrapper(IStudentUpdateCandidate Candidate, Student Entity);