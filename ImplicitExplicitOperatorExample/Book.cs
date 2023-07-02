namespace ImplicitExplicitOperatorExample;

public class Book
{
    public Book(string caption)
    {
        Caption = caption;
    }

    public Guid Id { get; private init; }
    public string Caption { get; private set; }
    public int Sites { get; private set; }
    public int Chapter { get; private set; }

    public static Book Create(string caption, int sites, int chapter)
    {
        return new Book(caption)
        {
            Id = Guid.NewGuid(),
            Sites = sites,
            Chapter = chapter
        };
    }
    
    public static implicit operator BookDto(Book book)
    {
        return new BookDto(book.Id, book.Caption, book.Sites, book.Chapter);
    }
}