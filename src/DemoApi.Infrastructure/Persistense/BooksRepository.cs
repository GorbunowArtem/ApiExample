using DemoApi.Core;
using DemoApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure.Persistense;

public class BooksRepository(BooksContext context) : IBooksRepository
{
    public async Task AddBookAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync() =>
        await context.Books
            .Include(b => b.Forms)
            .ThenInclude(f => f.Reader)
            .ToListAsync();
}