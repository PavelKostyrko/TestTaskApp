using Microsoft.EntityFrameworkCore;
using TestTaskApp.Data.Models;

namespace TestTaskApp.Data
{
    internal static class ModelBuilderExtension
    {
        internal static void AddData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>()
                .HasData(
                    new UserDb
                    {
                        Id = 1,
                        Name = "Olivia",
                        Age = 18,
                        Email = "IamOlivia@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 2,
                        Name = "Samuel",
                        Age = 21,
                        Email = "Samuel1@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 3,
                        Name = "Harry",
                        Age = 23,
                        Email = "Harry_Harry@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 4,
                        Name = "Thomas",
                        Age = 48,
                        Email = "tTthomas@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 5,
                        Name = "David",
                        Age = 11,
                        Email = "DavidDD@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 6,
                        Name = "Sophia",
                        Age = 33,
                        Email = "SophiaABC@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 7,
                        Name = "Lily",
                        Age = 27,
                        Email = "LilyYy@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 8,
                        Name = "Scarlett",
                        Age = 30,
                        Email = "Scarlett@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 9,
                        Name = "Charlie",
                        Age = 19,
                        Email = "charlieee@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 10,
                        Name = "Connor",
                        Age = 22,
                        Email = "1connor1@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 11,
                        Name = "Stanley",
                        Age = 21,
                        Email = "Ssstanley@gmail.com",
                        Roles = new List<RoleDb>()
                    },
                    new UserDb
                    {
                        Id = 12,
                        Name = "Lora",
                        Age = 29,
                        Email = "Lora123@gmail.com",
                        Roles = new List<RoleDb>()
                    }
                );

            modelBuilder.Entity<RoleDb>()
               .HasData(
                    new RoleDb
                    {
                        Id = 1,
                        Title = "User",
                        Users = new List<UserDb>()
        },
                    new RoleDb
                    {
                        Id = 2,
                        Title = "Admin",
                        Users = new List<UserDb>()
                    },
                    new RoleDb
                    {
                        Id = 3,
                        Title = "Support",
                        Users = new List<UserDb>()
                    },
                    new RoleDb
                    {
                        Id = 4,
                        Title = "SuperAdmin",
                        Users = new List<UserDb>()
                    }
                );
        }
    }
}
