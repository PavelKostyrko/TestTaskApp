using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestTaskApp.Data.Models;

namespace TestTaskApp.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleDb>
    {
        public void Configure(EntityTypeBuilder<RoleDb> builder)
        {
            
            builder.ToTable("Roles").HasKey(o => o.Id);
            builder.HasIndex(o => o.Title).IsUnique();
            builder.Property(o => o.Title).IsRequired();
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasMany(o => o.Users).WithMany(o => o.Roles);
        }
    }
}
