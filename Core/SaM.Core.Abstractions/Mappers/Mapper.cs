namespace SaM.Core.Abstractions.Mappers;

public abstract class Mapper<TFrom,TTo>
{
    public abstract TTo Map(TFrom from);

    public List<TTo> Map(List<TFrom> from)
    {
        return from.Select(Map).ToList();
    }
}