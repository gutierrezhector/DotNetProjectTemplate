using Microsoft.EntityFrameworkCore;

namespace SaM.Database.Core.Extensions;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder SetupSqlServer(this DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DYOUGI;Database=SaM;Trusted_Connection=True;TrustServerCertificate=True;",
            o => o.MigrationsAssembly("SaM.Database.Migrations"));
        return optionsBuilder;
    }
}