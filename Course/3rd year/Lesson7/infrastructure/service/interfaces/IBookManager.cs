namespace Lesson7;

public interface IBookManager
{
    public abstract void AddBook(Book newBook);
    public abstract void ResetBook(long bookId, string newName, string newAuthor);
    public abstract void DeleteBook(long bookId);
    public abstract IEnumerable<Book> GetAllBooks();
    public abstract dynamic GetBookById(long bookId);
}