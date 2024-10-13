namespace Lesson7;
using System.Text;
public class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

        var bookWorker = new JsonDataWorker("books.json");
        var userWorker = new JsonDataWorker("users.json");

        var booksData = bookWorker.ReadBookData();
        IBookManager bookManager = new BookManager(booksData);

        // Book book1 = new Book(1, "На дне", "Максим Горький");
        // Book book2 = new Book(2, "Война и мир", "Лев Толстой");
        // Book book3 = new Book(3, "Преступление и наказание", "Федор Достоевский");
        // Book book4 = new Book(4, "Мы", "Михаил Замятин");
        // Book book5 = new Book(5, "Олеся", "Александр Куприн");

        // bookManager.AddBook(book1);
        // bookManager.AddBook(book2);
        // bookManager.AddBook(book3);
        // bookManager.AddBook(book4);
        // bookManager.AddBook(book5);


        var usersData = userWorker.ReadUserData();
        IUserManager userManager = new UserManager(usersData);

        // userManager.CreateUser("Андрей");
        // userManager.CreateUser("Борис");
        // userManager.CreateUser("Владимир");
        // userManager.CreateUser("Иосиф");
        // userManager.CreateUser("Леонид");


        Console.WriteLine("Добро пожаловаль в MyLib! Выберите функцию:");
        Console.WriteLine("------------------------------------------------");
        bool flag = true;

        while (flag)
        {
            Console.WriteLine("Действия с книгами");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1: Добавить книгу");
            Console.WriteLine("2: Изменить книгу");
            Console.WriteLine("3: Удалить книгу");
            Console.WriteLine("4: Показать все книги");
            Console.WriteLine("5: Показать книгу по id");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Действия с пользователями");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("6: Создать пользователя");
            Console.WriteLine("7: Добавить пользователю книгу");
            Console.WriteLine("8: Удалить у пользователя книгу");
            Console.WriteLine("9: Удалить пользователя");
            Console.WriteLine("10: Показать всех пользователей");
            Console.WriteLine("11: Показать пользователя по id");
            Console.WriteLine("12: Выход");
            string ans = Console.ReadLine();
            switch(ans)
            {
                case ("1"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите название книги:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Введите автора:");
                    string author = Console.ReadLine();


                    var booksList = bookManager.GetAllBooks().ToList().OrderByDescending(b => b.BookId);
                    long maxId = booksList.ToList()[0].BookId + 1;
                    Book thisBook = new Book(maxId, name, author);

                    bookManager.AddBook(thisBook);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("2"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id книги:");
                    long resetingId = (long)Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите новое название книги:");
                    string newName = Console.ReadLine();

                    Console.WriteLine("Введите нового автора:");
                    string newAuthor = Console.ReadLine();


                    bookManager.ResetBook(resetingId, newName, newAuthor);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("3"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id книги:");
                    long deleteId = (long)Convert.ToDouble(Console.ReadLine());

                    bookManager.DeleteBook(deleteId);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("4"):
                    Console.WriteLine("------------------------------------------------");

                    var allBooks = bookManager.GetAllBooks();
                    foreach(Book book in allBooks)
                    {
                        Console.WriteLine($"{book.BookId}|{book.BookName}|{book.AuthorName}");
                    }

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("5"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id книги:");
                    long needId = (long)Convert.ToDouble(Console.ReadLine());
                    var needBook = bookManager.GetBookById(needId);
                    if (needBook == null)
                    {
                        Console.WriteLine($"Книги с id {needId} не существует");
                    }
                    else
                    {
                        Console.WriteLine($"{needBook.BookId}|{needBook.BookName}|{needBook.AuthorName}");
                    }

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("6"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите имя пользователя:");
                    string userName = Console.ReadLine();

                    userManager.CreateUser(userName);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("7"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id пользователя:");
                    long addingUserId = (long)Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите id книги:");
                    long addingBookId = (long)Convert.ToDouble(Console.ReadLine());

                    userManager.AddBookForUser(addingUserId, addingBookId);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("8"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id пользователя:");
                    long deletingUserId = (long)Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите id книги:");
                    long deletingBookId = (long)Convert.ToDouble(Console.ReadLine());

                    userManager.DeleteBookForUser(deletingUserId, deletingBookId);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("9"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id пользователя:");
                    long deleteUserId = (long)Convert.ToDouble(Console.ReadLine());

                    userManager.DeleteUser(deleteUserId);

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("10"):
                    Console.WriteLine("------------------------------------------------");

                    var allUsers = userManager.GetAllUsers().ToList().OrderBy(b => b.UserId);
                    foreach(User user in allUsers)
                    {
                        Console.WriteLine($"{user.UserId}|{user.UserName}|{String.Join(", ", user.UserBooks)}");
                    }

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("11"):
                    Console.WriteLine("------------------------------------------------");

                    Console.WriteLine("Введите id пользователя:");
                    long needUserId = (long)Convert.ToDouble(Console.ReadLine());
                    var needUser = userManager.GetUserById(needUserId);
                    if (needUser == null)
                    {
                        Console.WriteLine($"Пользователя с id {needUserId} не существует");
                    }
                    else
                    {
                        Console.WriteLine($"{needUser.UserId}|{needUser.UserName}|{String.Join(", ", needUser.UserBooks)}");
                    }

                    Console.WriteLine("------------------------------------------------");
                    break;
                case ("12"):
                    Console.WriteLine("Спасибо, что пользуетесь приложением!");
                    flag = false;
                    break;
                default:
                    break;
            }
        }
    }
}