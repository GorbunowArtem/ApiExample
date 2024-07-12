using AutoFixture;
using AutoMapper;
using DemoApi.Core;
using DemoApi.Core.Models;
using DemoApi.Core.Services;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;

namespace DemoApi.Tests
{
    public class BooksServiceTests
    {
        private readonly Mock<IBooksRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<BooksService>> _mockLogger;
        private readonly Mock<IValidator<BookViewModel>> _mockValidator;
        private readonly IFixture _fixture;

        private readonly BooksService _sut;

        public BooksServiceTests()
        {
            _mockRepository = new Mock<IBooksRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<BooksService>>();
            _mockValidator = new Mock<IValidator<BookViewModel>>();
            _fixture = new Fixture();

            _sut = new BooksService(
                _mockRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object,
                _mockValidator.Object);
        }

        [Fact]
        public async Task AddBookAsync_ValidBook_AddsBookToRepository()
        {
            // Arrange
            var book = _fixture.Create<BookViewModel>();
            var bookEntity = _fixture.Create<Book>();

            _mockValidator.Setup(v => v.ValidateAsync(book, default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            _mockMapper.Setup(m => m.Map<Book>(book)).Returns(bookEntity);

            // Act
            await _sut.AddBookAsync(book);

            // Assert
            _mockRepository.Verify(r => r.AddBookAsync(bookEntity), Times.Once);
        }

        [Fact]
        public async Task AddBookAsync_ValidBook_LogsBookAdded()
        {
            // Arrange
            var book = _fixture.Create<BookViewModel>();

            _mockValidator.Setup(v => v.ValidateAsync(book, default)).ReturnsAsync(new FluentValidation.Results.ValidationResult());

            // Act
            await _sut.AddBookAsync(book);

            // Assert
            _mockLogger.Verify(
                l => l.LogInformation("Book added with {Title} and {Isbn}", book.Title, book.Isbn),
                Times.Once);
        }

        [Fact]
        public async Task AddBookAsync_InvalidBook_LogsValidationErrors()
        {
            // Arrange
            var book = _fixture.Create<BookViewModel>();
            var validationErrors = _fixture.CreateMany<FluentValidation.Results.ValidationFailure>();

            var validationResult = new FluentValidation.Results.ValidationResult(validationErrors);

            _mockValidator.Setup(v => v.ValidateAsync(book, default)).ReturnsAsync(validationResult);

            // Act
            await _sut.AddBookAsync(book);

            // Assert
            var res = await _sut.GetBooksAsync();
            res.Should().BeEmpty();
        }

        [Fact]
        public async Task GetBooksAsync_ReturnsMappedBooks()
        {
            // Arrange
            var books = _fixture.CreateMany<Book>();
            var expectedBookViewModels = _fixture.CreateMany<BookViewModel>();

            _mockRepository.Setup(r => r.GetBooksAsync()).ReturnsAsync(books);
            
            _mockMapper.Setup(m => m.Map<IEnumerable<BookViewModel>>(books)).Returns(expectedBookViewModels);

            // Act
            var result = await _sut.GetBooksAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedBookViewModels);
        }
    }
}