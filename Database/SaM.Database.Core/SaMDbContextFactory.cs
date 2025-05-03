using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SaM.Database.Core.Extensions;

namespace SaM.Database.Core;

public class SaMDbContextFactory : IDesignTimeDbContextFactory<SaMDbContext>
{
    public SaMDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../..", "SaM.Start/Configs");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException("connectionString is null or empty");
            
        }
        
        var optionsBuilder = new DbContextOptionsBuilder<SaMDbContext>();
        optionsBuilder.SetupSqlServer(connectionString);

        return new SaMDbContext(optionsBuilder.Options);
    }
}