using Microsoft.EntityFrameworkCore;
using SaM.Database.Core;

namespace SaM.Core.Abstractions.Repository;

public abstract class BaseRepository(SaMDbContext dbContext)
{
    protected readonly SaMDbContext DbContext = dbContext;

    protected DbSet<T> Set<T>() where T : class
    {
        return DbContext.Set<T>();
    }

    protected Task SaveChangesAsync()
    {
        return DbContext.SaveChangesAsync();
    }
}