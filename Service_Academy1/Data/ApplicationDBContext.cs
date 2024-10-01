using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service_Academy1.Models;
using System;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ProgramsModel> Programs { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed roles (Admin, Instructor, Student)
        string adminRoleId = Guid.NewGuid().ToString();
        string instructorRoleId = Guid.NewGuid().ToString();
        string studentRoleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = instructorRoleId,
                Name = "Instructor",
                NormalizedName = "INSTRUCTOR"
            },
            new IdentityRole
            {
                Id = studentRoleId,
                Name = "Student",
                NormalizedName = "STUDENT"
            }
        );

        var hasher = new PasswordHasher<ApplicationUser>();

        // Seed an admin user
        string adminUserId = Guid.NewGuid().ToString();
        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            UserName = "admin@lms.com",
            NormalizedUserName = "ADMIN@LMS.COM",
            Email = "admin@lms.com",
            NormalizedEmail = "ADMIN@LMS.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            FullName = "Admin User",
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

        // Seed an instructor user
        string instructorUserId = Guid.NewGuid().ToString();
        var instructorUser = new ApplicationUser
        {
            Id = instructorUserId,
            UserName = "instructor@lms.com",
            NormalizedUserName = "INSTRUCTOR@LMS.COM",
            Email = "instructor@lms.com",
            NormalizedEmail = "INSTRUCTOR@LMS.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            FullName = "Instructor User",
        };
        instructorUser.PasswordHash = hasher.HashPassword(instructorUser, "Instructor@123");

        // Seed a student user
        string studentUserId = Guid.NewGuid().ToString();
        var studentUser = new ApplicationUser
        {
            Id = studentUserId,
            UserName = "student@lms.com",
            NormalizedUserName = "STUDENT@LMS.COM",
            Email = "student@lms.com",
            NormalizedEmail = "STUDENT@LMS.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            FullName = "Student User",
         
        };
        studentUser.PasswordHash = hasher.HashPassword(studentUser, "Student@123");

        // Add the users to the ApplicationUser entity
        builder.Entity<ApplicationUser>().HasData(adminUser, instructorUser, studentUser);

        // Assign roles to the seeded users
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            },
            new IdentityUserRole<string>
            {
                RoleId = instructorRoleId,
                UserId = instructorUserId
            },
            new IdentityUserRole<string>
            {
                RoleId = studentRoleId,
                UserId = studentUserId
            }
        );
    }
}
