namespace SaM.Core.Abstractions.Factories;

public abstract class EntityFactory<T, TDao, TCandidate>
{
    public abstract T CreateFromCandidate(TCandidate creationCandidate);
    public abstract T CreateFromDao(TDao from);

    public List<T> CreateFromDao(List<TDao> from)
    {
        return from.Select(CreateFromDao).ToList();
    }
}