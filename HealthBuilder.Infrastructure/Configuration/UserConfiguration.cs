using HealthBuilder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Username)
                .IsUnique();
            builder.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}