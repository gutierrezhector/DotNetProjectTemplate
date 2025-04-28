using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.Database.Core.Daos.Users;

namespace SaM.Database.Core.Configurations.Users;

public class UsersConfiguration : IEntityTypeConfiguration<UserDao>
{
    public void Configure(EntityTypeBuilder<UserDao> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(u => u.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(100)
            .IsRequired();
    }
}