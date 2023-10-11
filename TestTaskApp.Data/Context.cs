using Microsoft.EntityFrameworkCore;
using TestTaskApp.Data.Models;
using TestTaskApp.Data.Configurations;

namespace TestTaskApp.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<RoleDb> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.AddData();
        }
    }
}
