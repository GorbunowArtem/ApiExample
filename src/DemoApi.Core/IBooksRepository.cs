using DemoApi.Core.Models;

namespace DemoApi.Core;

public interface IBooksRepository
{
  Task AddBookAsync(Book book);
  
  Task<IEnumerable<Book>> GetBooksAsync();
}
