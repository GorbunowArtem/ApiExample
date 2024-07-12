using DemoApi.Core.Models;
using DemoApi.Core.Validators;
using Xunit;

namespace DemoApi.Tests.Validators;

public class BookValidatorTests
{
    [Fact]
    public void BookValidator_TitleIsEmpty_ResultIsFalse()
    {
        // Arrange
        var validator = new BookValidator();
        var book = new BookViewModel
        {
            Title = string.Empty,
            Isbn = 1231
        };

        // Act
        var result = validator.Validate(book);

        // Assert
        Assert.False(result.IsValid);
    } 
    
    [Theory]
    [InlineData("Thiss1")]
    [InlineData("Thiss133")]
    public void BookValidator_TitleIsLongerThanMaxValue_ResultIsFalse(string title)
    {
        // Arrange
        var validator = new BookValidator();
        var book = new BookViewModel
        {
            Title = title,
            Isbn = 1231
        };

        // Act
        var result = validator.Validate(book);

        // Assert
        Assert.False(result.IsValid);
    }
}