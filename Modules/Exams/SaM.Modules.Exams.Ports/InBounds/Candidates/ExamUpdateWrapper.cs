using SaM.Core.Types.Entities.Exams;

namespace SaM.Modules.Exams.Ports.InBounds.Candidates;

public record ExamUpdateWrapper(IExamUpdateCandidate Candidate, Exam Entity);