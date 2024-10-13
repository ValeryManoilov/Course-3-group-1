namespace Lesson7;

// using Linq;
public class BookManager : IBookManager
{
    public static JsonDataWorker userWorker = new JsonDataWorker("users.json");
    public static JsonDataWorker bookWorker = new JsonDataWorker("books.json");
    public static List<User> usersData = userWorker.ReadUserData();
    public static IUserManager userManager = new UserManager(usersData);
    private readonly List<Book> _books = new List<Book>();
    public BookManager()
    {
        _books = new List<Book>();
    }
    public BookManager(List<Book> books)
    {
        _books = books;
    }

    public void AddBook(Book newBook)
    {
        var book = _books.Where(b => b.BookId == newBook.BookId);
        if (book.ToList().Count != 0)
        {
            Console.WriteLine($"Книга '{newBook.BookName}' уже существует");
        }
        else
        {
            _books.Add(newBook);
            bookWorker.WriteBookData(_books);
            Console.WriteLine($"Книга '{newBook.BookName}' добавлена в библиотеку");
        }
    }
    public void ResetBook(long bookId, string newName, string newAuthor)
    {
        JsonDataWorker userWorker = new JsonDataWorker("users.json");
        List<User> usersData = userWorker.ReadUserData();
        IUserManager userManager = new UserManager(usersData);

        var book = _books.Where(b => b.BookId == bookId);
        if (book.ToList().Count == 0)
        {
            Book newBook = new Book(GetLastId(), newName, newAuthor);
            _books.Add(newBook);
            List<User> users = userManager.GetAllUsers();
            Console.WriteLine($"Книги с id {bookId} не существует, поэтому она была добавлена под id {GetLastId()}");
        }
        else
        {
            book.ToList()[0].BookName = newName;
            book.ToList()[0].AuthorName = newAuthor;
            List<User> users = userManager.GetAllUsers();
            foreach(User user in users)
            {
                if (user.UserBooks.Any(b => b.BookId == book.ToList()[0].BookId))
                {
                    userManager.ResetUserBook(user.UserId, bookId, newName, newAuthor);
                }
            }
            Console.WriteLine($"Книга перезаписана");
            bookWorker.WriteBookData(_books);
        }
    }
    public void DeleteBook(long bookId)
    {
        JsonDataWorker userWorker = new JsonDataWorker("users.json");
        List<User> usersData = userWorker.ReadUserData();
        IUserManager userManager = new UserManager(usersData);

        var book = _books.Where(b => b.BookId == bookId);
        if (book.ToList().Count != 0)
        {
            Book needBook = book.ToList()[0];
            _books.Remove(book.ToList()[0]);
            List<User> users = userManager.GetAllUsers();
            foreach(User user in users)
            {
                if (user.UserBooks.Any(b => b.BookId == needBook.BookId))
                {
                    userManager.DeleteBookForUser(user.UserId, needBook.BookId);
                }
            }
            bookWorker.WriteBookData(_books);
            Console.WriteLine($"Книга '{needBook.BookName}' удалена");
        }
        else
        {
            Console.WriteLine($"Книги с id {bookId} не существует");
        }
    }

    private long GetLastId()
    {
        var booksList = GetAllBooks().ToList().OrderByDescending(b => b.BookId);
        long maxId = booksList.ToList()[0].BookId + 1;
        return maxId;
    }
    public IEnumerable<Book> GetAllBooks()
    {
        return _books.ToList().OrderBy(b => b.BookId);
    }
    public dynamic GetBookById(long bookId)
    {
        var book = _books.Where(b => b.BookId == bookId);
        if (book.ToList().Count != 0)
        {
            return book.ToList()[0];
        }
        else
        {
            return null;
        }
    }

}