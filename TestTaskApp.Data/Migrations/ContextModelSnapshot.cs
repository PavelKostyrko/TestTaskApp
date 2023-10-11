﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTaskApp.Data;

#nullable disable

namespace TestTaskApp.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RoleDbUserDb", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleDbUserDb");
                });

            modelBuilder.Entity("TestTaskApp.Data.Models.RoleDb", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "User"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Support"
                        },
                        new
                        {
                            Id = 4,
                            Title = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("TestTaskApp.Data.Models.UserDb", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<byte?>("Age")
                        .IsRequired()
                        .HasColumnType("smallint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (byte)18,
                            Email = "IamOlivia@gmail.com",
                            Name = "Olivia"
                        },
                        new
                        {
                            Id = 2,
                            Age = (byte)21,
                            Email = "Samuel1@gmail.com",
                            Name = "Samuel"
                        },
                        new
                        {
                            Id = 3,
                            Age = (byte)23,
                            Email = "Harry_Harry@gmail.com",
                            Name = "Harry"
                        },
                        new
                        {
                            Id = 4,
                            Age = (byte)48,
                            Email = "tTthomas@gmail.com",
                            Name = "Thomas"
                        },
                        new
                        {
                            Id = 5,
                            Age = (byte)11,
                            Email = "DavidDD@gmail.com",
                            Name = "David"
                        },
                        new
                        {
                            Id = 6,
                            Age = (byte)33,
                            Email = "SophiaABC@gmail.com",
                            Name = "Sophia"
                        },
                        new
                        {
                            Id = 7,
                            Age = (byte)27,
                            Email = "LilyYy@gmail.com",
                            Name = "Lily"
                        },
                        new
                        {
                            Id = 8,
                            Age = (byte)30,
                            Email = "Scarlett@gmail.com",
                            Name = "Scarlett"
                        },
                        new
                        {
                            Id = 9,
                            Age = (byte)19,
                            Email = "charlieee@gmail.com",
                            Name = "Charlie"
                        },
                        new
                        {
                            Id = 10,
                            Age = (byte)22,
                            Email = "1connor1@gmail.com",
                            Name = "Connor"
                        },
                        new
                        {
                            Id = 11,
                            Age = (byte)21,
                            Email = "Ssstanley@gmail.com",
                            Name = "Stanley"
                        },
                        new
                        {
                            Id = 12,
                            Age = (byte)29,
                            Email = "Lora123@gmail.com",
                            Name = "Lora"
                        });
                });

            modelBuilder.Entity("RoleDbUserDb", b =>
                {
                    b.HasOne("TestTaskApp.Data.Models.RoleDb", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestTaskApp.Data.Models.UserDb", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}