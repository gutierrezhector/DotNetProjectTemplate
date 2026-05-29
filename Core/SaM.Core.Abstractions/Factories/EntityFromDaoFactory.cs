namespace SaM.Core.Abstractions.Factories;

public abstract class EntityFromDaoFactory<T, TDao>
{
    public abstract T CreateFromDao(TDao from);

    public List<T> CreateFromDao(List<TDao> from)
    {
        return from.Select(CreateFromDao).ToList();
    }
}
