namespace SaM.Core.Abstractions.Mappers;

public abstract class Mapper<TFrom, TTo>
{
    /// <summary>
    /// Method to implement in child mappers. The implementation should reflect the fact
    /// that TFrom should not be null in this context
    /// </summary>
    /// <param name="from">The entry model. It should not be null</param>
    /// <returns></returns>
    public abstract TTo MapNonNullable(TFrom from);
    
    public List<TTo> MapNonNullable(List<TFrom> from)
    {
        return from.Select(MapNonNullable).ToList();
    }
    
    public TTo? MapNullable(TFrom? from)
    {
        if (from is null)
        {
            return default;
        }

        return MapNonNullable(from);
    }
    
    public List<TTo>? MapNullable(List<TFrom>? from)
    {
        if (from is null)
        {
            return null;
        }
        
        return from.Select(MapNonNullable).ToList();
    }
}