using Microsoft.EntityFrameworkCore;

namespace SaM.Database.Core;

public class SaMDbContext(DbContextOptions options) : DbContext(options);

// dotnet ef migrations add InitialCreate -p C:\Perso\Projets\SaM\Database\SaM.Database.Core -o C:\Perso\Projets\SaM\Database\SaM.Database.Migrations -n C:\Perso\Projets\SaM\Database\SaM.Database.Migrations