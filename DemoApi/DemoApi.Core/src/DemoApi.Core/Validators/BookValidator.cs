using DemoApi.Core.Models;
using FluentValidation;

namespace DemoApi.Core.Validators;

public class BookValidator : AbstractValidator<BookViewModel>
{
    public BookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(5);
    }
}
