using DemoApi.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure;

public class BooksContext(DbContextOptions<BooksContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Form> Forms { get; set; }

    public DbSet<Reader> Readers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed a default user
        var hasher = new PasswordHasher<IdentityUser>();
        var passwordHash = hasher.HashPassword(null, "P@f0iujKTI9pWIPqRsem~");

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "default-user-id",
                UserName = "default@example.com",
                NormalizedUserName = "DEFAULT@EXAMPLE.COM", 
                Email = "default@example.com",
                NormalizedEmail = "DEFAULT@EXAMPLE.COM",
                PasswordHash = passwordHash,
                EmailConfirmed = false,
                LockoutEnabled = true
            });
    }
}