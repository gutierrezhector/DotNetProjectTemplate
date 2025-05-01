using Microsoft.EntityFrameworkCore;
using SaM.Database.Core;

namespace SaM.Core.Abstractions.Repository;

public abstract class BaseRepository<T>(SaMDbContext dbContext) where T : class
{
    protected readonly SaMDbContext DbContext = dbContext;

    protected abstract void ApplyIncludes(DbSet<T> set);
    
    protected DbSet<T> SetWithIncludes()
    {
        var set = DbContext.Set<T>();
        ApplyIncludes(set);
        
        return set;
    }
    
    protected DbSet<T> SetWithoutIncludes()
    {
        return DbContext.Set<T>();
    }

    protected Task SaveChangesAsync()
    {
        return DbContext.SaveChangesAsync();
    }
}