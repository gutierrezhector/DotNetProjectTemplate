namespace SaM.Core.Abstractions.Factories;

public abstract class ViewModelFactory<TViewModel, TEntity>
{
    public abstract TViewModel CreateFromEntity(TEntity entity);
    
    public List<TViewModel> CreateFromEntity(List<TEntity> from)
    {
        return from.Select(CreateFromEntity).ToList();
    }
}