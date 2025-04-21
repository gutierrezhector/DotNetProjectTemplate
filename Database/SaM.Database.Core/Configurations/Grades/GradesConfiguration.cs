using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Core.Daos.Grades;

namespace SaM.Database.Core.Configurations.Grades
{
    public class GradesConfiguration : IEntityTypeConfiguration<GradeDao>
    {
        public void Configure(EntityTypeBuilder<GradeDao> builder)
        {
            builder.ToTable("Grades");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(g => g.Notation)
                .HasPrecision(3, 1)
                .IsRequired();

            builder.HasOne(g => g.Exam)
                .WithMany(e => e.Grades)
                .HasForeignKey(g => g.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}