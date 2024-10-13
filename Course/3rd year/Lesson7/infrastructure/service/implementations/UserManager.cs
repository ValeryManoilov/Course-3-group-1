namespace Lesson7;
using System.Text.Json;
public class UserManager : IUserManager
{
    public static JsonDataWorker userWorker = new JsonDataWorker("users.json");


    private readonly List<User> _users = new List<User>();
    public UserManager()
    {
        _users = new List<User>();
    }
    public UserManager(List<User> users)
    {
        _users = users;
    }
    public void CreateUser(string newUserName)
    {
        User newUser = new User(GetLastId(), newUserName, new List<Book>());
        _users.Add(newUser);
        userWorker.WriteUserData(_users);
    }
    public void AddBookForUser(long userId, long bookId)
    {
        JsonDataWorker bookWorker = new JsonDataWorker("books.json");
        List<Book> booksData = bookWorker.ReadBookData();
        IBookManager bookManager = new BookManager(booksData);

        var user = _users.Where(u => u.UserId == userId);
        if (user.ToList().Count != 0)
        {
            User needUser = GetUserById(userId);
            Book needBook = bookManager.GetBookById(bookId);
            if (needBook != null)
            {
                if (!needUser.UserBooks.Any(b => b.BookId == needBook.BookId))
                {
                    user.ToList()[0].UserBooks.Add(needBook);
                    userWorker.WriteUserData(_users);
                    Console.WriteLine($"Книга '{needBook.BookName}' добавлена");
                }
                else
                {
                    Console.WriteLine($"Книга '{needBook.BookName}' уже есть в библиотеке пользователя");
                }
            }
            else
            {
                Console.WriteLine($"Книги с id {bookId} не существует");
            }
        }
        else
        {
            Console.WriteLine($"Пользователь с id {userId} не существует");
        }
    }

    public void DeleteBookForUser(long userId, long bookId)
    {
        JsonDataWorker bookWorker = new JsonDataWorker("books.json");
        List<Book> booksData = bookWorker.ReadBookData();
        IBookManager bookManager = new BookManager(booksData);

        var user = _users.Where(u => u.UserId == userId);
        if (user.ToList().Count != 0)
        {
            User needUser = GetUserById(userId);
            Book needBook = bookManager.GetBookById(bookId);
            if (needBook != null)
            {
                if (needUser.UserBooks.Any(b => b.BookId == needBook.BookId))
                {
                    needUser.UserBooks = needUser.UserBooks.Where(b => b.BookId != needBook.BookId).ToList();
                    userWorker.WriteUserData(_users);
                    Console.WriteLine($"Книга '{needBook.BookName}' удалена из библиотеки пользователя");
                }
                else
                {
                    Console.WriteLine($"Книги с id {bookId} нет в библиотеке пользователя");
                }
            }
            else
            {
                Console.WriteLine($"Книги с id {bookId} не существует");
            }
        }
        else
        {
            Console.WriteLine($"Пользователя с id {userId} не существует");
        }
    }

    public void ResetUserBook(long userId, long bookId, string newName, string newAuthor)
    {
        JsonDataWorker bookWorker = new JsonDataWorker("books.json");
        List<Book> booksData = bookWorker.ReadBookData();
        IBookManager bookManager = new BookManager(booksData);

        var user = _users.Where(u => u.UserId == userId);
        if (user.ToList().Count != 0)
        {
            User needUser = GetUserById(userId);
            Book needBook = bookManager.GetBookById(bookId);
            if (needBook != null)
            {
                if (needUser.UserBooks.Any(b => b.BookId == needBook.BookId))
                {
                    Book resetBook = needUser.UserBooks.FirstOrDefault(b => b.BookId == needBook.BookId);
                    resetBook.BookName = newName;
                    resetBook.AuthorName = newAuthor;
                    userWorker.WriteUserData(_users);
                    Console.WriteLine($"Книга '{needBook.BookName}' перезаписана в библиотеке пользователя");
                }
                else
                {
                    Console.WriteLine($"Книги с id {bookId} нет в библиотеке пользователя");
                }
            }
            else
            {
                Console.WriteLine($"Книги с id {bookId} не существует");
            }
        }
        else
        {
            Console.WriteLine($"Пользователя с id {userId} не существует");
        }
    }
    public void DeleteUser(long userId)
    {
        var user = _users.Where(u => u.UserId == userId);
        if (user.ToList().Count != 0)
        {
            Console.WriteLine($"Пользователь с id '{user.ToList()[0].UserName}' удалена");
            _users.Remove(user.ToList()[0]);
            userWorker.WriteUserData(_users);
        }
        else
        {
            Console.WriteLine($"Пользователь с id {userId} не существует");
        }
    }

    public long GetLastId()
    {
        var usersList = GetAllUsers().ToList().OrderByDescending(u => u.UserId);
        if (usersList.ToList().Count != 0)
        {
            long maxId = usersList.ToList()[0].UserId + 1;
            return maxId;
        }
        else
        {
            return 1;
        }
    }
    public List<User> GetAllUsers()
    {
        return _users.ToList();
    }
    public dynamic GetUserById(long userId)
    {
        var user = _users.Where(u => u.UserId == userId);
        if (user.ToList().Count != 0)
        {
            return user.ToList()[0];
        }
        else
        {
            return null;
        }
    }
}