using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SaM.Database.Core;

public class SaMDbContextFactory : IDesignTimeDbContextFactory<SaMDbContext>
{
    public SaMDbContext CreateDbContext(string[] args)
    {        
        var optionsBuilder = new DbContextOptionsBuilder<SaMDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=MSI;Database=SaM;Trusted_Connection=True;");        
        
        return new SaMDbContext(optionsBuilder.Options);
    }
}