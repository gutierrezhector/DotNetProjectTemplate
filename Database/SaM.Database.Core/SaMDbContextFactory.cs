using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SaM.Database.Core.Extensions;

namespace SaM.Database.Core;

public class SaMDbContextFactory : IDesignTimeDbContextFactory<SaMDbContext>
{
    public SaMDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SaMDbContext>();
        optionsBuilder.SetupSqlServer();

        return new SaMDbContext(optionsBuilder.Options);
    }
}