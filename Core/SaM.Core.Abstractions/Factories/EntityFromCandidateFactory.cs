namespace SaM.Core.Abstractions.Factories;

public abstract class EntityFromCandidateFactory<T, TCandidate>
{
    public abstract T CreateFromCandidate(TCandidate creationCandidate);
}
