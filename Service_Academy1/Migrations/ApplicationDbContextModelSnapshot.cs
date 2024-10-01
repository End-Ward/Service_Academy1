﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceAcademy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2bf41183-0923-48ec-b3b0-d11bd51a309c",
                            Email = "admin@lms.com",
                            EmailConfirmed = true,
                            FullName = "Admin User",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LMS.COM",
                            NormalizedUserName = "ADMIN@LMS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMQ4t/ReiRwmVT6iCXqtoB97mQ3kVSyzKSu4TEw2clh1egJ2opUMa4j0EhlylnruVA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8d603c2a-c778-4481-92e7-30cbd5915f75",
                            TwoFactorEnabled = false,
                            UserName = "admin@lms.com"
                        },
                        new
                        {
                            Id = "b9c4bf84-a325-41f2-9b4b-46aa02644a0e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4f4ad1b6-0524-42b3-852e-22e6d87316ce",
                            Email = "instructor@lms.com",
                            EmailConfirmed = true,
                            FullName = "Instructor User",
                            LockoutEnabled = false,
                            NormalizedEmail = "INSTRUCTOR@LMS.COM",
                            NormalizedUserName = "INSTRUCTOR@LMS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ1xUqPXw6YkH7ZAM1vaFXimq//rz+6cQ4gaTqVivsDzHMStZ1K+vloTbbgGMUtJgw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "50f8628b-099f-457b-99cd-fbe1e3d5c460",
                            TwoFactorEnabled = false,
                            UserName = "instructor@lms.com"
                        },
                        new
                        {
                            Id = "653a1ce8-11fa-4a30-a1f3-a0a227478029",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4482bb6b-f90b-48c7-bd9c-206238aa7856",
                            Email = "student@lms.com",
                            EmailConfirmed = true,
                            FullName = "Student User",
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@LMS.COM",
                            NormalizedUserName = "STUDENT@LMS.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOZyhW914JZT/4YRiwVBE56Ppj1KjTvIJI9uGSvky4Mc1CCJaEEZzfxMWyBp6J+2dQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45efc3d5-f7b6-48f5-9cab-02339e856ba6",
                            TwoFactorEnabled = false,
                            UserName = "student@lms.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "55161bc9-3a3c-4665-a9d0-5f646edb7b96",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "164358e0-6909-4376-9cea-8d18f75ddcfc",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        },
                        new
                        {
                            Id = "91c06316-da62-47bb-90a0-da914ee692a7",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e",
                            RoleId = "55161bc9-3a3c-4665-a9d0-5f646edb7b96"
                        },
                        new
                        {
                            UserId = "b9c4bf84-a325-41f2-9b4b-46aa02644a0e",
                            RoleId = "164358e0-6909-4376-9cea-8d18f75ddcfc"
                        },
                        new
                        {
                            UserId = "653a1ce8-11fa-4a30-a1f3-a0a227478029",
                            RoleId = "91c06316-da62-47bb-90a0-da914ee692a7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Service_Academy1.Models.ProgramsModel", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProgramId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InstructorId")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProgramId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Service_Academy1.Models.ProgramsModel", b =>
                {
                    b.HasOne("ApplicationUser", "currentInstructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.Navigation("currentInstructor");
                });
#pragma warning restore 612, 618
        }
    }
}
