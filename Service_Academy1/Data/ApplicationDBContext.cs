using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Service_Academy1.Models;
using System;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
    options)
    : base(options)
    {
    }
    public DbSet<ProgramsModel> Programs { get; set; }
    public DbSet<ProgramManagementModel> ProgramManagement { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Remove any HasData or other seed data logic from here!
        // Define your model structure, relationships, indexes, etc.
    }
}
