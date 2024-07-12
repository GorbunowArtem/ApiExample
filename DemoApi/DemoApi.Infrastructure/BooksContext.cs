using DemoApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure;

public class BooksContext : DbContext
{
    public BooksContext()
    {
        
    }
    
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Form> Forms { get; set; }

    public DbSet<Reader> Readers { get; set; }
}