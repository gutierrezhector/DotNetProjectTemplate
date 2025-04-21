using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Core.Daos.Students;

namespace SaM.Database.Core.Configurations.Students;

public class StudentsConfiguration : IEntityTypeConfiguration<StudentDao>
{
    public void Configure(EntityTypeBuilder<StudentDao> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(s => s.User);

        builder.HasMany(s => s.Grades)
            .WithOne(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}