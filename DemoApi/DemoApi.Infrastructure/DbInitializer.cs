using DemoApi.Core.Models;

namespace DemoApi.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(BooksContext context)
    {
        var books = new Book[]
        {
            new()
            {
                Title = "The Great Gatsby",
                Isbn = 3214
            },
            new()
            {
                Title = "Moby Dick",
                Isbn = 56546
            }
        };

        context.Books.AddRange(books);
        context.SaveChanges();

        var readers = new Reader[]
        {
            new()
            {
                Id = 11,
                Address = "Lviv",
                Name = "John Doe",
            },
            new()
            {
                Id = 22,
                Address = "Rivne",
                Name = "Jane Doe",
            },
        };

        context.Readers.AddRange(readers);
        context.SaveChanges();

        var forms = new Form[]
        {
            new Form
            {
                Id = 111,
                IssuedDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddMonths(1),
                BookId = books[0].Id,
                ReaderId = 11
            },
            new Form
            {
                Id = 222,
                IssuedDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddMonths(2),
                BookId = books[1].Id,
                ReaderId = 22
            },
        };

        context.Forms.AddRange(forms);
        context.SaveChanges();
    }
}