using Microsoft.EntityFrameworkCore;

namespace SaM.Database.Core.Extensions;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder SetupSqlServer(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder.UseSqlServer(
            connectionString,
            o => o.MigrationsAssembly("SaM.Database.Migrations"));
        return optionsBuilder;
    }
}