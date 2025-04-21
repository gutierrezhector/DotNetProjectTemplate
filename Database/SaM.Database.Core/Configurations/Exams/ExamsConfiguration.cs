using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Core.Daos.Exams;

namespace SaM.Database.Core.Configurations.Exams;

public class ExamsConfiguration : IEntityTypeConfiguration<ExamDao>
{
    public void Configure(EntityTypeBuilder<ExamDao> builder)
    {
        builder.ToTable("Exams");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired();

        builder.Property(e => e.MaxPoints)
            .HasPrecision(3, 1)
            .IsRequired();

        builder.HasOne(e => e.ResponsibleTeacher)
            .WithMany(e => e.Exams)
            .HasForeignKey(e => e.ResponsibleTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Grades)
            .WithOne(e => e.Exam)
            .HasForeignKey(e => e.ExamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}