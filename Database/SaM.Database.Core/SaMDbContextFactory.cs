using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SaM.Database.Core;

public class SaMDbContextFactory : IDesignTimeDbContextFactory<SaMDbContext>
{
    public SaMDbContext CreateDbContext(string[] args)
    {        
        var optionsBuilder = new DbContextOptionsBuilder<SaMDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=DYOUGI;Database=SaM;Trusted_Connection=True;TrustServerCertificate=True;",
            o => o.MigrationsAssembly("SaM.Database.Migrations"));
        
        return new SaMDbContext(optionsBuilder.Options);
    }
}