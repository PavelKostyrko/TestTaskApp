using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestTaskApp.Data.Models;

namespace TestTaskApp.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.ToTable("Users").HasKey(o => o.Id);
            builder.HasIndex(o => o.Email).IsUnique();
            builder.Property(o => o.Email).IsRequired();
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Age).IsRequired();
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasMany(o => o.Roles).WithMany(o => o.Users);
        }
    }
}
