using Microsoft.EntityFrameworkCore;
using SaM.Database.Core.Configurations.Exams;
using SaM.Database.Core.Configurations.Grades;
using SaM.Database.Core.Configurations.Students;
using SaM.Database.Core.Configurations.Teachers;
using SaM.Database.Core.Configurations.Users;

namespace SaM.Database.Core;

public class SaMDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExamsConfiguration());
        modelBuilder.ApplyConfiguration(new GradesConfiguration());
        modelBuilder.ApplyConfiguration(new StudentsConfiguration());
        modelBuilder.ApplyConfiguration(new TeachersConfiguration());
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}