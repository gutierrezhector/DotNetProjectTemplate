using Microsoft.EntityFrameworkCore;
using SaM.Database.Core;

namespace SaM.Core.Abstractions.Repository;

public abstract class BaseRepository<T>(SaMDbContext dbContext) where T : class
{
    protected readonly SaMDbContext DbContext = dbContext;

    protected abstract IQueryable<T> ApplyIncludes(DbSet<T> set);

    protected IQueryable<T> SetWithIncludes()
    {
        return ApplyIncludes(DbContext.Set<T>());
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