using FluentAssertions;
using Xunit;
namespace ImplicitExplicitOperatorExample;

public class Tests
{
    [Fact]
    public void ImplicitWay()
    {
        var book = Book.Create("The to global", 1337, 2);
        
        //Implicit
        BookDto bookDto = book;

        bookDto.Should().BeOfType(typeof(BookDto));
        bookDto.Id.Should().Be(book.Id);
        bookDto.Caption.Should().Be(book.Caption);
        bookDto.Sites.Should().Be(book.Sites);
        bookDto.Chapter.Should().Be(book.Chapter);
    }
    
    [Fact]
    public void ExplicitWay()
    {
        var book = Book.Create("The flatearther", 123, 12);
        
        //Explicit
        var bookDto = (BookDto) book;

        bookDto.Should().BeOfType(typeof(BookDto));
        bookDto.Id.Should().Be(book.Id);
        bookDto.Caption.Should().Be(book.Caption);
        bookDto.Sites.Should().Be(book.Sites);
        bookDto.Chapter.Should().Be(book.Chapter);
    }
}