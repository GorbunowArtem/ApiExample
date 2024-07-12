using AutoMapper;
using DemoApi.Core.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DemoApi.Core.Services;

public class BooksService(
  IBooksRepository repository,
  IMapper mapper,
  ILogger<BooksService> logger,
  IValidator<BookViewModel> validator)
{
  public async Task AddBookAsync(BookViewModel book)
  {
    logger.LogInformation("Adding a new book with title {Title} and ISBN {Isbn}", book.Title, book.Isbn);

    var validationResult = await validator.ValidateAsync(book);

    if (validationResult.IsValid)
    {
     await repository.AddBookAsync(mapper.Map<Book>(book));

      logger.LogInformation("Book added with {Title} and {Isbn}", book.Title, book.Isbn);
      return;
    }

    logger.LogError("Validation failed for properties {@NotValidProperties}",
      validationResult.Errors.Select(vr => new { vr.PropertyName, vr.ErrorMessage }));
  }

  public async Task<IEnumerable<BookViewModel>> GetBooksAsync()
  {
    var books = await repository.GetBooksAsync();
   
    return mapper.Map<IEnumerable<BookViewModel>>(books);
  }
}
