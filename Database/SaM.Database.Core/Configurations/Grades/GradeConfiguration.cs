using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Data.Daos.Grades;

namespace SaM.Database.Core.Configurations.Grades
{
    public class GradeConfiguration : IEntityTypeConfiguration<GradeDao>
    {
        public void Configure(EntityTypeBuilder<GradeDao> builder)
        {
            builder.ToTable("Grades");
            builder.HasKey(x => x.Id);
            builder.Property(g => g.Notation).IsRequired();
        }
    }
}