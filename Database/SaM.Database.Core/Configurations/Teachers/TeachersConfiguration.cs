using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Core.Daos.Teachers;

namespace SaM.Database.Core.Configurations.Teachers;

public class TeachersConfiguration : IEntityTypeConfiguration<TeacherDao>
{
    public void Configure(EntityTypeBuilder<TeacherDao> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(x => x.Id);

        builder.Property(teacher => teacher.SchoolSubject)
            .HasConversion<string>();

        builder
            .HasOne(t => t.User)
            .WithOne();

        builder
            .HasMany(t => t.Exams)
            .WithOne(e => e.ResponsibleTeacher)
            .HasForeignKey(x => x.ResponsibleTeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}